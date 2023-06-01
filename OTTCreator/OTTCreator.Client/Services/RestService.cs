using System.Diagnostics;
using System.Text;
using System.Text.Json;
using OTTCreator.Client.Models;

namespace OTTCreator.Client.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public List<ContentItem> ContentItems { get; private set; }

        public RestService()
        {
#if DEBUG
            _httpsClientHandlerService = new HttpsClientHandlerService();
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<ContentItem>> GetContentItemsAsync()
        {
            ContentItems = new List<ContentItem>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + "contentitems", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ContentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ContentItems;
        }

        public async Task<List<ContentItem>> GetContentItemsAsync(string type, string category)
        {
            ContentItems = new List<ContentItem>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + type + "/" + category + "/contentitems", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ContentItems = JsonSerializer.Deserialize<List<ContentItem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ContentItems;
        }

        public async Task<ContentItem> GetContentItemAsync(int id)
        {
            ContentItem contentItem = new ContentItem();

            Uri uri = new Uri(string.Format(Constants.APIUrl + "contentitems/" + id, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    contentItem = JsonSerializer.Deserialize<ContentItem>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return contentItem;
        }

        public async Task<List<string>> GetTypesAsync()
        {
            var types = new List<string>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + "types", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    types = JsonSerializer.Deserialize<List<string>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return types;
        }

        public async Task<List<string>> GetCategoriesAsync(string type)
        {
            var categories = new List<string>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + type + "/categories", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<string>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return categories;
        }

        public async Task<List<ContentItem>> GetFavoritesAsync(string type)
        {
            var favorites = new List<ContentItem>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + type + "/contentitems/favorites/", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    favorites = JsonSerializer.Deserialize<List<ContentItem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return favorites;
        }

        public async Task<List<ContentItem>> GetRecommendedAsync(string type)
        {
            var recommended = new List<ContentItem>();

            Uri uri = new Uri(string.Format(Constants.APIUrl + type + "/contentitems/recommended/", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    recommended = JsonSerializer.Deserialize<List<ContentItem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return recommended;
        }

        public async Task SaveContentItemFavoriteAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.APIUrl+"contentitems/"+id+"/favorite", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<int>(id, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tContentItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteContentItemAsync(string id)
        {
            Uri uri = new Uri(string.Format("", id));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tContentItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
