﻿using CommunityToolkit.Maui.Views;
using OTTCreator.Client.Models;
using OTTCreator.Client.Services;

namespace OTTCreator.Client.Pages
{
    public partial class ContentItemPage : ContentPage
    {
        private ContentItem currentItem;
        private bool isCustomPlaybackControlsVisible;
        private bool isContentItemPlaying;
        private bool hasVideo;
        private MediaSource currentStreamMediaSource;
        private Uri audioCoverImageBackup;
        private ContentService contentService;
        
        public ContentItemPage()
        {
            InitializeComponent();

            contentService = new ContentService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var currentID = await SecureStorage.Default.GetAsync("CurrentID");
            if (currentID == null)
                currentID = "1";

            currentItem = await contentService.GetContentItemAsync(Convert.ToInt32(currentID));
            var currentStream = currentItem.Stream.ToString();

            var currentVolume = await SecureStorage.Default.GetAsync("CurrentVolume");
            if (currentVolume == null)
                currentVolume = ContentItemMediaElement.Volume.ToString();
            ContentItemMediaElement.Volume = Convert.ToSingle(currentVolume);

            var currentAspect = await SecureStorage.Default.GetAsync("CurrentAspect");

            if (currentStream != ContentItemMediaElement.Source.ToString().Replace("Uri: ", ""))
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
                    if (currentAspect == "AspectFill")
                        AudioCoverImage.Aspect = Aspect.AspectFill;
                    else if (currentAspect == "Fill")
                        AudioCoverImage.Aspect = Aspect.Fill;
                    else if (currentAspect == "Center")
                        AudioCoverImage.Aspect = Aspect.Center;
                    else if (currentAspect == "AspectFit")
                        AudioCoverImage.Aspect = Aspect.AspectFit;
                    AudioCoverImage.Source = currentItem.Image;
                    AudioCoverImage.IsVisible = true;
                    audioCoverImageBackup = currentItem.Image;
                }
                else
                {
                    hasVideo = true;
                    AudioCoverImage.IsVisible = false;
                    if (currentAspect == "AspectFill")
                        ContentItemMediaElement.Aspect = Aspect.AspectFill;
                    else if (currentAspect == "Fill")
                        ContentItemMediaElement.Aspect = Aspect.Fill;
                    else if (currentAspect == "Center")
                        ContentItemMediaElement.Aspect = Aspect.Center;
                    else if (currentAspect == "AspectFit")
                        ContentItemMediaElement.Aspect = Aspect.AspectFit;
                    ContentItemMediaElement.IsVisible = true;
                }

                Title = currentItem.Name;
            }
            
            AudioCoverImage.Source = audioCoverImageBackup;
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            await SecureStorage.Default.SetAsync("CurrentVolume", ContentItemMediaElement.Volume.ToString());
            if (hasVideo)
                await SecureStorage.Default.SetAsync("CurrentAspect", ContentItemMediaElement.Aspect.ToString());
            else
                await SecureStorage.Default.SetAsync("CurrentAspect", AudioCoverImage.Aspect.ToString());


            AudioCoverImage.Source = null;
        }

        private async void ContentItemMediaElement_MediaOpened(object sender, EventArgs e)
        {
            isContentItemPlaying = true;
            await CustomPlaybackControls.FadeTo(0, 500);
            isCustomPlaybackControlsVisible = false;
        }

        private async void Grid_Tapped(object sender, EventArgs args)
        {
            if (isCustomPlaybackControlsVisible)
            {
                await CustomPlaybackControls.FadeTo(0, 500);
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
                await CustomPlaybackControls.FadeTo(1, 500);
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
            await contentService.SaveContentItemFavoriteAsync(currentItem.ID);
        }
    }
}
