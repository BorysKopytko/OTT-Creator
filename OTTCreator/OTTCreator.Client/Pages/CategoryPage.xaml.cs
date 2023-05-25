using OTTCreator.Client.Data;

namespace OTTCreator.Client.Pages;

public partial class CategoryPage : ContentPage
{
    ClientDatabase clientDatabase;
    string previousType;
    string previousCategory;

    public CategoryPage()
    {
        InitializeComponent();
    }

    private async Task GenerateContentItemList()
    {
        ContentItemList.Clear();
        var contentItems = await clientDatabase.GetItemsAsync();
        foreach (var contentItem in contentItems.Where(x => x.Type == Shell.Current.CurrentItem.Title && x.Category == Shell.Current.CurrentItem.CurrentItem.Title).Distinct().ToList())
        {
            var imageButton = new ImageButton();
            imageButton.Source = contentItem.Image;
            imageButton.Aspect = Aspect.Fill;
            imageButton.CommandParameter = contentItem.ID;
            imageButton.MaximumHeightRequest = 300;
            imageButton.MaximumWidthRequest = 300;
            imageButton.BorderWidth = 5;
            imageButton.Clicked += ImageButton_Clicked;
            ContentItemList.Add(imageButton);
        }
        previousType = Shell.Current.CurrentItem.Title;
        previousCategory = Shell.Current.CurrentItem.CurrentItem.Title;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var imageButtonCommandParameter = (int)((ImageButton)sender).CommandParameter;
        await SecureStorage.Default.SetAsync("CurrentID", imageButtonCommandParameter.ToString());
        await Shell.Current.GoToAsync("//ContentItemPage");
    }

    protected override async void OnAppearing()
    {
        if ((previousType == null && previousCategory == null) || (previousType != Shell.Current.CurrentItem.Title) || (previousCategory != Shell.Current.CurrentItem.CurrentItem.Title))
        {
            if (clientDatabase == null)
                clientDatabase = new ClientDatabase();
            await GenerateContentItemList();
            Title = Shell.Current.CurrentItem.Title;
        }

        base.OnAppearing();
    }
}
