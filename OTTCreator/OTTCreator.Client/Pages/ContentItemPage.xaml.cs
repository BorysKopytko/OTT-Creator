using CommunityToolkit.Maui.Views;

namespace OTTCreator.Client
{
    public partial class ContentItemPage : ContentPage
    {
        public ContentItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var currentStream = await SecureStorage.Default.GetAsync("CurrentStream");
            if (ContentItemMediaElement.Source == null || currentStream != ContentItemMediaElement.Source.ToString())
                ContentItemMediaElement.Source = currentStream;
        }
 
    }
}
