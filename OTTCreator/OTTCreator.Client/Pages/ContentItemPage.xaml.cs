using CommunityToolkit.Maui.Views;
using OTTCreator.Client.Data;
using OTTCreator.Client.Models;

namespace OTTCreator.Client.Pages
{
    public partial class ContentItemPage : ContentPage
    {
        private ClientDatabase clientDatabase;
        private ContentItem currentItem;
        private bool isCustomPlaybackControlsVisible;
        private bool isContentItemPlaying;
        private bool hasVideo;
        private MediaSource currentStreamMediaSource;
        private Uri audioCoverImageBackup;
        
        public ContentItemPage()
        {
            InitializeComponent();

            clientDatabase = new ClientDatabase();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var currentID = await SecureStorage.Default.GetAsync("CurrentID");
            if (currentID == null)
                currentID = "1";

            currentItem = await clientDatabase.GetItemAsync(Convert.ToInt32(currentID));
            var currentStream = currentItem.Stream.ToString();

            if (currentStream != ContentItemMediaElement.Source.ToString().Replace("Uri: ", "") || currentStream == "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
            {
                ContentItemMediaElement.Source = currentStream;

                if (!currentItem.IsLive)
                {
                    CustomPlaybackControls.IsVisible = false;
                    ContentItemMediaElement.ShouldShowPlaybackControls = true;
                }
                else
                {
                    ContentItemMediaElement.ShouldShowPlaybackControls = false;
                    CustomPlaybackControls.IsVisible = true;
                }

                if (!currentItem.HasVideo)
                {
                    hasVideo = false;
                    ContentItemMediaElement.IsVisible = false;
                    AudioCoverImage.Source = currentItem.Image;
                    AudioCoverImage.IsVisible = true;
                    audioCoverImageBackup = currentItem.Image;
                }
                else
                {
                    hasVideo = true;
                    AudioCoverImage.IsVisible = false;
                    ContentItemMediaElement.IsVisible = true;
                }

                Title = currentItem.Name;
            }
            
            AudioCoverImage.Source = audioCoverImageBackup;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            AudioCoverImage.Source = null;
        }

        private async void ContentItemMediaElement_MediaOpened(object sender, EventArgs e)
        {
            isContentItemPlaying = true;
            await CustomPlaybackControls.FadeTo(0, 2000);
            isCustomPlaybackControlsVisible = false;
        }

        private async void Grid_Tapped(object sender, EventArgs args)
        {
            if (isCustomPlaybackControlsVisible)
            {
                await CustomPlaybackControls.FadeTo(0, 1000);
                isCustomPlaybackControlsVisible = false;
                AspectButton.IsEnabled = false;
                VolumeDownButton.IsEnabled = false;
                StopAndPlayButton.IsEnabled = false;
                VolumeUpButton.IsEnabled = false;
                FavoriteButton.IsEnabled = false;
            }
            else
            {
                AspectButton.IsEnabled = true;
                VolumeDownButton.IsEnabled = true;
                StopAndPlayButton.IsEnabled = true;
                VolumeUpButton.IsEnabled = true;
                FavoriteButton.IsEnabled = true;
                await CustomPlaybackControls.FadeTo(1, 1000);
                isCustomPlaybackControlsVisible = true;
            }
        }

        private void VolumeDownButton_Clicked(object sender, EventArgs e)
        {
            if (ContentItemMediaElement.Volume != 0.0)
                ContentItemMediaElement.Volume = double.Round(double.Round(ContentItemMediaElement.Volume, 1) - double.Round(0.1, 1), 1);
        }

        private void StopAndPlayButton_Clicked(object sender, EventArgs e)
        {
            if (isContentItemPlaying)
            {
                ContentItemMediaElement.Stop();
                currentStreamMediaSource = ContentItemMediaElement.Source;
                ContentItemMediaElement.Source = "";
                isContentItemPlaying = false;
            }
            else
            {
                ContentItemMediaElement.Source = currentStreamMediaSource;
                ContentItemMediaElement.Play();
                isContentItemPlaying = true;
            }
        }

        private void VolumeUpButton_Clicked(object sender, EventArgs e)
        {
            if (ContentItemMediaElement.Volume != 1.0)
                ContentItemMediaElement.Volume = double.Round(double.Round(ContentItemMediaElement.Volume, 1) + double.Round(0.1, 1), 1);
        }

        private void AspectButton_Clicked(object sender, EventArgs e)
        {
            if (hasVideo)
            {
                if (ContentItemMediaElement.Aspect == Aspect.AspectFit)
                    ContentItemMediaElement.Aspect = Aspect.AspectFill;
                else if (ContentItemMediaElement.Aspect == Aspect.AspectFill)
                    ContentItemMediaElement.Aspect = Aspect.Fill;
                else if (ContentItemMediaElement.Aspect == Aspect.Fill)
                    ContentItemMediaElement.Aspect = Aspect.Center;
                else
                    ContentItemMediaElement.Aspect = Aspect.AspectFit;
            }
            else
            {
                if (AudioCoverImage.Aspect == Aspect.AspectFit)
                    AudioCoverImage.Aspect = Aspect.AspectFill;
                else if (AudioCoverImage.Aspect == Aspect.AspectFill)
                    AudioCoverImage.Aspect = Aspect.Fill;
                else if (AudioCoverImage.Aspect == Aspect.Fill)
                    AudioCoverImage.Aspect = Aspect.Center;
                else
                    AudioCoverImage.Aspect = Aspect.AspectFit;
            }

        }

        private async void FavoriteButton_Clicked(object sender, EventArgs e)
        {
            currentItem.IsFavorite = !currentItem.IsFavorite;
            await clientDatabase.SaveItemAsync(currentItem);
        }
    }
}
