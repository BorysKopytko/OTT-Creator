using CommunityToolkit.Maui.Views;
using OTTCreator.Client.Data;

namespace OTTCreator.Client
{
    public partial class ContentItemPage : ContentPage
    {
        ClientDatabase clientDatabase;
        bool isCustomPlaybackControlsVisible;
        bool isContentItemPlaying;
        MediaSource currentStreamMediaSource;
        bool hasContentItemVideo;
        Uri audioCoverImageBackup;

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
            var currentItem = await clientDatabase.GetItemAsync(Convert.ToInt32(currentID));
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
                    ContentItemMediaElement.IsVisible = false;
                    hasContentItemVideo = false;
                    AudioCoverImage.Source = currentItem.Image;
                    AudioCoverImage.IsVisible = true;
                    audioCoverImageBackup = currentItem.Image;
                }
                else
                {
                    AudioCoverImage.IsVisible = false;
                    ContentItemMediaElement.IsVisible = true;
                    hasContentItemVideo = true;
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

        private async void Grid_Tapped(object sender, EventArgs args)
        {
            if (isCustomPlaybackControlsVisible)
            {
                await CustomPlaybackControls.FadeTo(0, 1000);
                isCustomPlaybackControlsVisible = false;
                VolumeDownButton.IsEnabled = false;
                StopAndPlayButton.IsEnabled = false;
                VolumeUpButton.IsEnabled = false;
            }
            else
            {
                VolumeDownButton.IsEnabled = true;
                StopAndPlayButton.IsEnabled = true;
                VolumeUpButton.IsEnabled = true;
                await CustomPlaybackControls.FadeTo(1, 1000);
                isCustomPlaybackControlsVisible = true;
            }
        }

        private async void ContentItemMediaElement_MediaOpened(object sender, EventArgs e)
        {
            isContentItemPlaying = true;
            await CustomPlaybackControls.FadeTo(0, 2000);
            isCustomPlaybackControlsVisible = false;
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
    }
}
