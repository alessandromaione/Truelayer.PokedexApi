using Pokedex.Core;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Infrastructure.ExternalClients
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;

        public PokeApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.ApiName.PokeApiClient);
        }

        public async Task<ApiResult<PokemonSpecies>> GetAsync(string pokemonName)
        {
            return await _httpClient.ApiReadAsync<PokemonSpecies>($"pokemon-species/{pokemonName}");
        }
    }
}