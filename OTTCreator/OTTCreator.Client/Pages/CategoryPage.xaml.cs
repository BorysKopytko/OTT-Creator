using OTTCreator.Client.Data;
using OTTCreator.Client.Models;

namespace OTTCreator.Client.Pages
{
    public partial class CategoryPage : ContentPage
    {
        private ClientDatabase clientDatabase;
        private string previousType;
        private string previousCategory;

        public CategoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if ((previousType == null && previousCategory == null) || (previousType != Shell.Current.CurrentItem.Title) || (previousCategory != Shell.Current.CurrentItem.CurrentItem.Title))
            {
                if (clientDatabase == null)
                    clientDatabase = new ClientDatabase();

                await GenerateContentItemList();

                Title = Shell.Current.CurrentItem.Title;
            }
        }

        private async Task GenerateContentItemList()
        {
            ContentItemList.Clear();

            var contentItems = await clientDatabase.GetItemsAsync();
            List<ContentItem> filteredContentItems = new List<ContentItem>();
            if (Shell.Current.CurrentItem.Title == "Улюблений вміст")
                filteredContentItems = contentItems.Where(x => x.Type == Shell.Current.CurrentItem.CurrentItem.Title && x.IsFavorite == true).Distinct().ToList();
            else
                filteredContentItems = contentItems.Where(x => x.Type == Shell.Current.CurrentItem.Title && x.Category == Shell.Current.CurrentItem.CurrentItem.Title).Distinct().ToList();
            foreach (var contentItem in filteredContentItems)
            {
                var imageButton = new ImageButton() { CommandParameter = contentItem.ID, Source = contentItem.CroppedImage, Aspect = Aspect.AspectFill, MinimumHeightRequest = 105, MinimumWidthRequest = 105, MaximumHeightRequest = 196, MaximumWidthRequest = 196, Margin = 5 };
                imageButton.Clicked += ImageButton_Clicked;
                ContentItemList.Add(imageButton);
            }

            if (Shell.Current.CurrentItem.Title != "Улюблений вміст")
            {
                previousType = Shell.Current.CurrentItem.Title;
                previousCategory = Shell.Current.CurrentItem.CurrentItem.Title;
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var imageButtonCommandParameter = (int)((ImageButton)sender).CommandParameter;
            await SecureStorage.Default.SetAsync("CurrentID", imageButtonCommandParameter.ToString());
            await Shell.Current.GoToAsync("//ContentItemPage");
        }
    }
}