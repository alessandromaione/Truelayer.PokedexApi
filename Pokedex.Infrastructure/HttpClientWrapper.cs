using Pokedex.Core.Results;
using System.Text.Json;

namespace Pokedex.Infrastructure
{
    public static class HttpClientWrapper
    {
        public static async Task<ApiResult<T>> ApiReadAsync<T>(this HttpClient httpClient, string requestUri)
        {
            try
            {
                var response = await httpClient.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                using var contentStream =
                                   await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<T>(contentStream, options);
            }
            catch (HttpRequestException httpEx) when (httpEx.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return httpEx;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static async Task<ApiResult<T>> ApiPostAsync<T>(this HttpClient httpClient, string requestUri, HttpContent httpContent)
        {
            try
            {
                var response = await httpClient.PostAsync(requestUri, httpContent);

                response.EnsureSuccessStatusCode();

                using var contentStream =
                                   await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<T>(contentStream, options);
            }
            catch (HttpRequestException httpEx) when (httpEx.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return httpEx;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}