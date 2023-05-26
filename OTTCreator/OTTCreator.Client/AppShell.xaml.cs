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
            clientDatabase = null;

            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        }

        private async Task GenerateUI()
        {
            var contentItems = await clientDatabase.GetItemsAsync();
            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                var UIType = new FlyoutItem() { Title = type };
                foreach (var category in contentItems.Where(x => x.Type == type).Select(x => x.Category).Distinct().ToList())
                {
                    var UICategory = new ShellContent();
                    UICategory.Title = category;
                    UICategory.ContentTemplate = new DataTemplate(typeof(CategoryPage));
                    UIType.Items.Add(UICategory);
                }
                Shell.Items.Add(UIType);
            }
        }
    }
}
