using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using System.Net.Http.Json;

namespace Pokedex.Infrastructure.ExternalClients
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public PokeApiClient(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public Task<PokemonSpecies?> GetAsync(string pokemonName)
        {
            return _httpClientWrapper.ReadAsync<PokemonSpecies>($"pokemon-species/{pokemonName}");
        }
    }
}