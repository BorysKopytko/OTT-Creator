using OTTCreator.Client.Data;
using OTTCreator.Client.Models;

namespace OTTCreator.Client
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ClientDatabase clientDatabase;

        public MainPage(ClientDatabase _clientDatabase)
        {
            InitializeComponent();
            clientDatabase = _clientDatabase;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            var contentItemForCreate = new ContentItem() { Name = "Test content 1", Category = "Test category A", Type = "Test type I", Logotype = new System.Uri("https://example.com/"), Stream = new System.Uri("https://example.com/") };
            await clientDatabase.SaveItemAsync(contentItemForCreate);

            var contentItemForUpdate = await clientDatabase.GetItemAsync(contentItemForCreate.ID);
            contentItemForUpdate.Name = "Test content 1.1";
            await clientDatabase.SaveItemAsync(contentItemForUpdate);

            var contentItemForDelete = await clientDatabase.GetItemAsync(contentItemForUpdate.ID);
            await clientDatabase.DeleteItemAsync(contentItemForDelete);
        }
    }
}