using OTTCreator.Client.Data;
//using OTTCreator.Client.Models;
using OTTCreator.Client.Pages;

namespace OTTCreator.Client
{
    public partial class App : Application
    {
        //ClientDatabase clientDatabase;

        public App()
        {
            InitializeComponent();

            //clientDatabase = new ClientDatabase();
            //var task = Task.Run(GetTestData);
            //task.Wait();
            //clientDatabase = null;

            MainPage = new AppShell();

            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        }

        //private async Task GetTestData()
        //{
        //    var contentItemForCreate = new ContentItem() { Name = "Test content 1", Category = "Test category A", Type = "Test type I", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 2", Category = "Test category A", Type = "Test type I", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 3", Category = "Test category B", Type = "Test type I", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 4", Category = "Test category B", Type = "Test type I", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 5", Category = "Test category C", Type = "Test type II", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 6", Category = "Test category C", Type = "Test type II", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 7", Category = "Test category D", Type = "Test type II", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("https://ythls.onrender.com/channel/UCkyrSWEcjZKpIwMxiPfOcgg.m3u8") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //    contentItemForCreate = new ContentItem() { Name = "Test content 8", Category = "Test category D", Type = "Test type II", Image = new System.Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new System.Uri("http://hbbtvlive.v3.tvp.pl/hbbtvlive/livestream.php?app_id=tvpinfo") };
        //    await clientDatabase.SaveItemAsync(contentItemForCreate);
        //}
    }
}
