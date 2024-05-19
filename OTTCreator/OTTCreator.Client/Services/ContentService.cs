using OTTCreator.Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace OTTCreator.Client.Services
{
    public class ContentService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        HttpsClientHandlerService httpsClientHandlerService;

        public ContentService()
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

        public async Task<bool> ActivateAsync(bool activateOrDeactivate, string WebAPIkey, string code)
        {
            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/activate/{activateOrDeactivate}/{WebAPIkey}/{code}", string.Empty));

            try
            {
                var json = JsonSerializer.Serialize<string>(code, serializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
                return false;
            }
        }

        public async Task<List<ContentItem>> GetContentItemsAsync()
        {
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/contentitems/{WebAPIkey}/{code}", string.Empty));
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
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");
            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/{type}/{category}/contentitems/{WebAPIkey}/{code}", string.Empty));
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

            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/contentitems/{id}/{WebAPIkey}/{code}", string.Empty));
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
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");

            var contentItemsStrings = new List<string>();

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/types/{WebAPIkey}/{code}", string.Empty));
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
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");

            var contentItemsStrings = new List<string>();

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/{type}/categories/{WebAPIkey}/{code}", string.Empty));
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
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");

            var contentItems = new List<ContentItem>();

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/{type}/contentitems/favorites/{WebAPIkey}/{code}", string.Empty));
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
            var WebAPIkey = await SecureStorage.Default.GetAsync("WebAPIKey");
            var code = await SecureStorage.Default.GetAsync("Code");

            var uri = new Uri(string.Format($"{Constants.WebAPIUrl}/contentitems/{id}/favorite/{WebAPIkey}/{code}", string.Empty));

            try
            {
                var json = JsonSerializer.Serialize(id, serializerOptions);
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
