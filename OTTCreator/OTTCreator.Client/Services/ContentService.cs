using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public class ContentService : IContentService
    {
        IRestService _restService;

        public ContentService()
        {
            _restService = new RestService();
        }
        public Task<List<ContentItem>> GetContentItemsAsync()
        {
            return _restService.GetContentItemsAsync();
        }
        public Task<List<ContentItem>> GetContentItemsAsync(string type, string category)
        {
            return _restService.GetContentItemsAsync(type, category);
        }
        public Task<ContentItem> GetContentItemAsync(int id)
        {
            return _restService.GetContentItemAsync(id);
        }

        public Task<List<string>> GetTypesAsync()
        {
            return _restService.GetTypesAsync();
        }
        public Task<List<string>> GetCategoriesAsync(string type)
        {
            return _restService.GetCategoriesAsync(type);
        }
        public Task<List<ContentItem>> GetFavoritesAsync(string type)
        {
            return _restService.GetFavoritesAsync(type);
        }
        public Task<List<ContentItem>> GetRecommendedAsync(string type)
        {
            return _restService.GetRecommendedAsync(type);
        }
        public Task SaveContentItemFavoriteAsync(int id)
        {
            return _restService.SaveContentItemFavoriteAsync(id);
        }

        public Task DeleteContentItemAsync(ContentItem contentItem)
        {
            return _restService.DeleteContentItemAsync(contentItem.ID.ToString());
        }
    }
}
