using OTTCreator.Client.Data;
using OTTCreator.Client.Models;
using OTTCreator.Client.Pages;

namespace OTTCreator.Client
{
    public partial class App : Application
    {
        ClientDatabase clientDatabase;

        public App()
        {
            InitializeComponent();

            if (Constants.isTestDataNeeded)
            {
                clientDatabase = new ClientDatabase();
                var task = Task.Run(GetTestData);
                task.Wait();
                clientDatabase = null;
            }

            MainPage = new AppShell();

            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        }

        private async Task GetTestData()
        {
            var contentItemForCreate = new ContentItem() { Name = "Test content 1", Category = "Test category A", Type = "Test type I", HasVideo = true, IsLive=true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://bloomberg.com/media-manifest/streams/eu.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 2", Category = "Test category A", Type = "Test type I", HasVideo = true, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://i.mjh.nz/PlutoTV/5a6b92f6e22a617379789618-alt.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 3", Category = "Test category B", Type = "Test type I", HasVideo = true, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 4", Category = "Test category B", Type = "Test type I", HasVideo = true, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 5", Category = "Test category C", Type = "Test type II", HasVideo = false, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.hitfm.ua/HitFM_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 6", Category = "Test category C", Type = "Test type II", HasVideo = false, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.radioroks.ua/RadioROKS_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 7", Category = "Test category D", Type = "Test type II", HasVideo = false, IsLive = true, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.hitfm.ua/HitFM_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 8", Category = "Test category D", Type = "Test type II", HasVideo = true, IsLive = false, Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
        }
    }
}
