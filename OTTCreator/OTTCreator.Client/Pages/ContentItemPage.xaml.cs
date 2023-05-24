using OTTCreator.Client.Data;

namespace OTTCreator.Client
{
    public partial class ContentItemPage : ContentPage
    {
        ClientDatabase clientDatabase;

        public ContentItemPage()
        {
            InitializeComponent();

            clientDatabase = new ClientDatabase();
        }

        protected override async void OnAppearing()
        {
            var currentID = await SecureStorage.Default.GetAsync("CurrentID");
            if (currentID == null)
                currentID = "1";
            var currentItem = await clientDatabase.GetItemAsync(Convert.ToInt32(currentID));
            var currentStream = currentItem.Stream.ToString();
            if (currentStream != ContentItemMediaElement.Source.ToString().Replace("Uri: ", ""))
            {
                ContentItemMediaElement.Source = currentStream;
                if (!currentItem.HasVideo)
                {
                    AudioCoverImage.Source = currentItem.Image;
                    AudioCoverImage.IsVisible = true;
                }
                else
                {
                    AudioCoverImage.IsVisible = false;
                }
                Title = currentItem.Name;
            }
            
            base.OnAppearing();
        }
    }
}
