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
            var currentItem = await clientDatabase.GetItemAsync(Convert.ToInt32(currentID));
            var currentStream = currentItem.Stream.ToString();
            if (currentStream != ContentItemMediaElement.Source.ToString().Replace("Uri: ", ""))
            {
                ContentItemMediaElement.Source = currentStream;
                Image.Source = currentItem.Image;
                Title = currentItem.Name;
            }
            
            base.OnAppearing();
        }
    }
}
