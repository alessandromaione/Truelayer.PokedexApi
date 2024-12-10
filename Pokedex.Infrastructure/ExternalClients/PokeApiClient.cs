using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using System.Net.Http.Json;

namespace Pokedex.Infrastructure.ExternalClients
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;

        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public Task<PokemonSpecies> GetAsync(string pokemonName)
        {
            return _httpClient.GetFromJsonAsync<PokemonSpecies>($"pokemon-species/{pokemonName}");
        }
    }
}