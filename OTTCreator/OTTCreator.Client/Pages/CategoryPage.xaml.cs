using OTTCreator.Client.Data;

namespace OTTCreator.Client.Pages;

public partial class CategoryPage : ContentPage
{
    ClientDatabase clientDatabase;

    public CategoryPage()
    {
        InitializeComponent();
        clientDatabase = new ClientDatabase();
        var task = Task.Run(GenerateContentItemList);
        task.Wait();
        Title = Shell.Current.CurrentItem.Title;
    }

    private async Task GenerateContentItemList()
    {
        var contentItems = await clientDatabase.GetItemsAsync();
        foreach (var contentItem in contentItems.Where(x => x.Type == Shell.Current.CurrentItem.Title && x.Category == Shell.Current.CurrentItem.CurrentItem.Title).Distinct().ToList())
        {
            var imageButton = new ImageButton();
            imageButton.Source = contentItem.Image;
            imageButton.CommandParameter = contentItem.ID;
            imageButton.MaximumHeightRequest = 150;
            imageButton.MaximumWidthRequest = 150;
            imageButton.BorderWidth = 5;
            imageButton.Clicked += ImageButton_Clicked;
            ContentItemList.Add(imageButton);
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var imageButtonCommandParameter = (int)((ImageButton)sender).CommandParameter;
        await SecureStorage.Default.SetAsync("CurrentID", imageButtonCommandParameter.ToString());
        await Shell.Current.GoToAsync("//ContentItemPage");
    }
}
