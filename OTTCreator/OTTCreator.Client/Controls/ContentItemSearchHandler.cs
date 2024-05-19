using OTTCreator.Client.Models;
using OTTCreator.Client.Services;
using Microsoft.Maui.Storage;

namespace OTTCreator.Client.Controls;

public class ContentItemSearchHandler : SearchHandler
{
    private ContentService contentService;

    public IList<ContentItem> ContentItems { get; set; }
    public Type SelectedItemNavigationTarget { get; set; }
    
    public ContentItemSearchHandler()
    {
        contentService = new ContentService();
        var task = Task.Run(GetContentItems);
        task.Wait();
    }

    private async Task GetContentItems()
    {
        var contentItems = await contentService.GetContentItemsAsync();
        ContentItems = contentItems;
    }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
            ItemsSource = null;
        else
            ItemsSource = ContentItems.Where(contentItem => contentItem.Name.ToLower().Contains(newValue.ToLower())).ToList();
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        await Task.Delay(1000);

        await SecureStorage.Default.SetAsync("CurrentID", ((ContentItem)item).ID.ToString());
        await Shell.Current.GoToAsync("//ContentItemPage");
    }
}
