using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public class ContentService
    {
        RestService restService;

        public ContentService()
        {
            restService = new RestService();
        }

        public Task<List<ContentItem>> GetContentItemsAsync()
        {
            return restService.GetContentItemsAsync();
        }

        public Task<List<ContentItem>> GetContentItemsAsync(string type, string category)
        {
            return restService.GetContentItemsAsync(type, category);
        }

        public Task<ContentItem> GetContentItemAsync(int id)
        {
            return restService.GetContentItemAsync(id);
        }

        public Task<List<string>> GetTypesAsync()
        {
            return restService.GetTypesAsync();
        }

        public Task<List<string>> GetCategoriesAsync(string type)
        {
            return restService.GetCategoriesAsync(type);
        }

        public Task<List<ContentItem>> GetFavoritesAsync(string type)
        {
            return restService.GetFavoritesAsync(type);
        }

        public Task SaveContentItemFavoriteAsync(int id)
        {
            return restService.SaveContentItemFavoriteAsync(id);
        }

        public Task<bool> ActivateAsync(bool activateOrDeactivate, string apikey, string code)
        {
            return restService.ActivateAsync(activateOrDeactivate, apikey,code);
        }
    }
}
