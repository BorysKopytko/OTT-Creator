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
            var currentName = await SecureStorage.Default.GetAsync("CurrentName");
            Title = currentName;
            var currentStream = await SecureStorage.Default.GetAsync("CurrentStream");
            if (ContentItemMediaElement.Source == null || currentStream != ContentItemMediaElement.Source.ToString())
                ContentItemMediaElement.Source = currentStream;
        }
    }
}
