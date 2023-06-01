using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public interface IContentService
    {
        Task<List<ContentItem>> GetContentItemsAsync(string type, string category);
        public Task<List<ContentItem>> GetContentItemsAsync();
        public Task<ContentItem> GetContentItemAsync(int id);
        Task<List<string>> GetTypesAsync();
        Task<List<string>> GetCategoriesAsync(string type);
        Task<List<ContentItem>> GetFavoritesAsync(string type);
        Task<List<ContentItem>> GetRecommendedAsync(string type);
        Task SaveContentItemFavoriteAsync(int id);
        Task DeleteContentItemAsync(ContentItem contentItem);
    }
}
