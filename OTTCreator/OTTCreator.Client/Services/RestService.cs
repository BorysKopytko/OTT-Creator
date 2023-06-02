using System.Diagnostics;
using System.Text;
using System.Text.Json;
using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public class RestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        HttpsClientHandlerService httpsClientHandlerService;

        public RestService()
        {
#if DEBUG
            httpsClientHandlerService = new HttpsClientHandlerService();
            var handler = httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                client = new HttpClient(handler);
            else
                client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<ContentItem>> GetContentItemsAsync()
        {
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/contentitems", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItems;
        }

        public async Task<List<ContentItem>> GetContentItemsAsync(string type, string category)
        {
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/{type}/{category}/contentitems", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItems;
        }

        public async Task<ContentItem> GetContentItemAsync(int id)
        {
            var contentItem = new ContentItem();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/contentitems/{id}", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItem = JsonSerializer.Deserialize<ContentItem>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItem;
        }

        public async Task<List<string>> GetTypesAsync()
        {
            var contentItemsStrings = new List<string>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/types", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItemsStrings = JsonSerializer.Deserialize<List<string>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItemsStrings;
        }

        public async Task<List<string>> GetCategoriesAsync(string type)
        {
            var contentItemsStrings = new List<string>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/{type}/categories", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItemsStrings = JsonSerializer.Deserialize<List<string>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItemsStrings;
        }

        public async Task<List<ContentItem>> GetFavoritesAsync(string type)
        {
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/{type}/contentitems/favorites/", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItems;
        }

        public async Task<List<ContentItem>> GetRecommendedAsync(string type)
        {
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.APIUrl}/{type}/contentitems/recommended/", string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return contentItems;
        }

        public async Task SaveContentItemFavoriteAsync(int id)
        {
            var uri = new Uri(string.Format($"{Constants.APIUrl}/contentitems/{id}/favorite", string.Empty));

            try
            {
                var json = JsonSerializer.Serialize<int>(id, serializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tContentItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }
    }
}
