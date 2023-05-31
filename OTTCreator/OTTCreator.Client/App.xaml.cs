﻿using OTTCreator.Client.Data;
using OTTCreator.Client.Models;

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
            }

            MainPage = new AppShell();
        }

        private async Task GetTestData()
        {
            var contentItemForCreate = new ContentItem() { Name = "Test content 1", Category = "Test category A", Type = "Телеканали", HasVideo = true, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Stream = new Uri("https://bloomberg.com/media-manifest/streams/eu.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 2", Category = "Test category A", Type = "Телеканали", HasVideo = true, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://i.mjh.nz/PlutoTV/5a6b92f6e22a617379789618-alt.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 3", Category = "Test category B", Type = "Телеканали", HasVideo = true, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 4", Category = "Test category B", Type = "Телеканали", HasVideo = true, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 5", Category = "Test category C", Type = "Радіостанції", HasVideo = false, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.hitfm.ua/HitFM_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 6", Category = "Test category C", Type = "Радіостанції", HasVideo = false, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.radioroks.ua/RadioROKS_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 7", Category = "Test category D", Type = "Радіостанції", HasVideo = false, IsLive = true, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("https://online.hitfm.ua/HitFM_HD") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
            contentItemForCreate = new ContentItem() { Name = "Test content 8", Category = "Test category D", Type = "Радіостанції", HasVideo = true, IsLive = false, IsFavorite = false, CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"), Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"), Stream = new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);
        }
    }
}
