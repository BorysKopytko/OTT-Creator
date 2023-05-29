using OTTCreator.Client.Data;
using OTTCreator.Client.Pages;

namespace OTTCreator.Client
{
    public partial class AppShell : Shell
    {
        private ClientDatabase clientDatabase;

        public AppShell()
        {
            InitializeComponent();

            clientDatabase = new ClientDatabase();
            var task = Task.Run(GenerateUI);
            task.Wait();

            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        }

        private async Task GenerateUI()
        {
            var contentItems = await clientDatabase.GetItemsAsync();

            var categoryPageDataTemplate = new DataTemplate(typeof(CategoryPage));

            var UIFavoritesFlyoutItem = new FlyoutItem() { Title = "Улюблений вміст" };
            var UIRecommendationsFlyoutItem = new FlyoutItem() { Title = "Рекомендований вміст" };
            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                UIFavoritesFlyoutItem.Items.Add(new ShellContent() { Title = type, ContentTemplate = categoryPageDataTemplate });
                UIRecommendationsFlyoutItem.Items.Add(new ShellContent() { Title = type, ContentTemplate = categoryPageDataTemplate });
            }
            Shell.Items.Add(UIFavoritesFlyoutItem);
            Shell.Items.Add(UIRecommendationsFlyoutItem);

            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                var UIType = new FlyoutItem() { Title = type };
                foreach (var category in contentItems.Where(x => x.Type == type).Select(x => x.Category).Distinct().ToList())
                    UIType.Items.Add(new ShellContent() { Title = category, ContentTemplate = categoryPageDataTemplate });
                Shell.Items.Add(UIType);
            }
        }
    }
}
