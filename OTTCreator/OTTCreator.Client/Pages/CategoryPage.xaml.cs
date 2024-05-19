using OTTCreator.Client.Models;
using OTTCreator.Client.Services;
using Microsoft.Maui.Storage;

namespace OTTCreator.Client.Pages;

public partial class CategoryPage : ContentPage
{
    private ContentService contentService;
    private string previousType;
    private string previousCategory;

    public CategoryPage()
    {
        InitializeComponent();
        contentService = new ContentService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if ((previousType == null && previousCategory == null) || (previousType != Shell.Current.CurrentItem.Title) ||
            (previousCategory != Shell.Current.CurrentItem.CurrentItem.Title))
        {
            await GenerateContentItemList();
        }

        Title = Shell.Current.CurrentItem.Title;
    }

    private async Task GenerateContentItemList()
    {
        ContentItemList.Clear();

        List<ContentItem> contentItems = new List<ContentItem>();
        if (Shell.Current.CurrentItem.Title == "Улюблений вміст")
            contentItems = await contentService.GetFavoritesAsync(Shell.Current.CurrentItem.CurrentItem.Title);
        else
            contentItems = await contentService.GetContentItemsAsync(Shell.Current.CurrentItem.Title, Shell.Current.CurrentItem.CurrentItem.Title);

        foreach (var contentItem in contentItems)
        {
            var imageButton = new ImageButton() { CommandParameter = contentItem.ID, Source = contentItem.CroppedImage, Aspect = Aspect.AspectFill, 
                MinimumHeightRequest = 105, MinimumWidthRequest = 105, MaximumHeightRequest = 196, MaximumWidthRequest = 196, Margin = 5, CornerRadius = 5 };
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
