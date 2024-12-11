using Pokedex.Core.Abstractions.HttpClients;
using System.Text.Json;

namespace Pokedex.Infrastructure
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> ReadAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
            else
            {
                using var contentStream =
                    await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<T>(contentStream, options);
            }
        }
    }
}
