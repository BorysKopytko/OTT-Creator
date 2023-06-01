using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public interface IRestService
    {
        Task<List<ContentItem>> GetContentItemsAsync();
        Task<List<ContentItem>> GetContentItemsAsync(string type, string category);

        Task<ContentItem> GetContentItemAsync(int id);

        Task<List<string>> GetTypesAsync();

        Task<List<string>> GetCategoriesAsync(string type);

        Task<List<ContentItem>> GetFavoritesAsync(string type);

        Task<List<ContentItem>> GetRecommendedAsync(string type);

        Task SaveContentItemFavoriteAsync(int id);

        Task DeleteContentItemAsync(string id);
    }
}
