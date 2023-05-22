using OTTCreator.Client.Data;
//using OTTCreator.Client.Models;
using OTTCreator.Client.Pages;

namespace OTTCreator.Client
{
    public partial class AppShell : Shell
    {
        ClientDatabase clientDatabase;

        public AppShell()
        {
            InitializeComponent();
            clientDatabase = new ClientDatabase();
            var task = Task.Run(GenerateUI);
            task.Wait();
        }

        private async Task GenerateUI()
        {
            //await GetTestUI();
            var contentItems = await clientDatabase.GetItemsAsync();
            foreach (var type in contentItems.Select(x => x.Type).Distinct().ToList())
            {
                var UIType = new FlyoutItem() { Title = type };
                foreach (var category in contentItems.Where(x => x.Type == type).Select(x => x.Category).Distinct().ToList())
                {
                    var UICategory = new ShellContent();
                    UICategory.Title = category;
                    UICategory.ContentTemplate = new DataTemplate(() => new CategoryPage());
                    UIType.Items.Add(UICategory);
                }
                Shell.Items.Add(UIType);
            }
        }

        //private async Task GetTestUI()
        //{
        //    var contentItemForCreate = new ContentItem() { Name = "Test content 1", Category = "Test category A", Type = "Test type I", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 2", Category = "Test category A", Type = "Test type I", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 3", Category = "Test category B", Type = "Test type I", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 4", Category = "Test category B", Type = "Test type I", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 5", Category = "Test category C", Type = "Test type II", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 6", Category = "Test category C", Type = "Test type II", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 7", Category = "Test category D", Type = "Test type II", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 8", Category = "Test category D", Type = "Test type II", Logotype = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //}
    }
}
