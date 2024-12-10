using System.Text;
using System.Web;
using System.Net.Http;

namespace USBComWebUI.Components.Util
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private string _token;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // GET Request with optional query parameters
        public async Task<string> GetAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            try
            {
                // Build query string if queryParams is provided
                if (queryParams != null && queryParams.Count > 0)
                {
                    var queryString = HttpUtility.ParseQueryString(string.Empty);
                    foreach (var param in queryParams)
                    {
                        queryString[param.Key] = param.Value;
                    }

                    endpoint = $"{endpoint}?{queryString}";
                }

                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network issues)
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // POST Request
        public async Task<string> PostAsync(string endpoint, string jsonData)
        {
            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // PUT Request
        public async Task<string> PutAsync(string endpoint, string jsonData)
        {
            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // DELETE Request
        public async Task<string> DeleteAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
