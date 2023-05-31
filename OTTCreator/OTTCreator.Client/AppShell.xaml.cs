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

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
            Routing.RegisterRoute("SupportPage", typeof(SupportPage));
        }

        private async Task GenerateUI()
        {
            var contentItems = await clientDatabase.GetItemsAsync();

            var categoryPageDataTemplate = new DataTemplate(typeof(CategoryPage));

            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                FavoriteContentFlyoutItem.Items.Add(new ShellContent() { Title = type, ContentTemplate = categoryPageDataTemplate });
                RecommendedContentFlyoutItem.Items.Add(new ShellContent() { Title = type, ContentTemplate = categoryPageDataTemplate });
            }

            var firstDefaultShellContentsCount = 3;
            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                var UIType = new FlyoutItem() { Title = type };
                foreach (var category in contentItems.Where(x => x.Type == type).Select(x => x.Category).Distinct().ToList())
                    UIType.Items.Add(new ShellContent() { Title = category, ContentTemplate = categoryPageDataTemplate });
                Shell.Items.Insert(firstDefaultShellContentsCount, UIType);
                firstDefaultShellContentsCount++;
            }
        }
    }
}
