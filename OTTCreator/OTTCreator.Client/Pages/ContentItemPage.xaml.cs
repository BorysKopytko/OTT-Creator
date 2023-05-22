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
            var currentStream = await SecureStorage.Default.GetAsync("CurrentStream");
            if (currentStream != ContentItemMediaElement.Source.ToString().Replace("Uri: ", ""))
            {
                ContentItemMediaElement.Source = currentStream;
                var currentName = await SecureStorage.Default.GetAsync("CurrentName");
                Title = currentName;
            }

            base.OnAppearing();
        }
    }
}
