using OTTCreator.Client.Data;

namespace OTTCreator.Client.Pages;

public partial class CategoryPage : ContentPage
{
    ClientDatabase clientDatabase;

    public CategoryPage()
	{
		InitializeComponent();
        clientDatabase = new ClientDatabase();
        var task = Task.Run(async () => { await GenerateContentItemList(); });
        task.Wait();
    }

    private async Task GenerateContentItemList()
	{
        var contentItems = await clientDatabase.GetItemsAsync();
        foreach (var contentItem in contentItems.Where(x=>x.Type==Shell.Current.CurrentItem.Title && x.Category==Shell.Current.CurrentItem.CurrentItem.Title).Distinct().ToList())
        {
            var imageButton = new ImageButton();
            imageButton.Source = contentItem.Logotype;
            imageButton.CommandParameter = contentItem.Name;
            imageButton.MaximumHeightRequest = 150;
            imageButton.MaximumWidthRequest = 150;
            imageButton.BorderWidth = 5;
            //imageButton.Clicked = ;
            ContentItemList.Add(imageButton);
        }
    }
}