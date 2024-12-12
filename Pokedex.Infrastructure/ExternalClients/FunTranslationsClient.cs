using Pokedex.Core;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using Pokedex.Core.Results;
using System.Web;

namespace Pokedex.Infrastructure.ExternalClients
{
    public class FunTranslationsClient : IFunTranslationsClient
    {
        private readonly HttpClient _httpClient;

        public FunTranslationsClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.ApiName.FunTranslationClient);
        }

        public Task<ApiResult<Translation>> TranslateToYodaAsync(string description)
        {
            return GetTranslation(description, Constants.TranslationType.Yoda);
        }

        public Task<ApiResult<Translation>> TranslateToShakespeareAsync(string description)
        {
            return GetTranslation(description, Constants.TranslationType.Shakespeare);
        }

        private async Task<ApiResult<Translation>> GetTranslation(string description, string type)
        {
            var values = new Dictionary<string, string>
            {
                { "text", description }
            };
            var content = new FormUrlEncodedContent(values);

            return await _httpClient.ApiPostAsync<Translation>($"{type}.json", content);
        }
    }
}