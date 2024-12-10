using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Abstractions.Services;
using Pokedex.Core.Models;

namespace Pokedex.Core.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiClient _pokeApiClient;

        public PokemonService(IPokeApiClient pokeApiClient)
        {
            _pokeApiClient = pokeApiClient;
        }

        public Task<PokemonSpecies> GetAsync(string pokemonName)
        {
            return _pokeApiClient.GetAsync(pokemonName);
        }
    }
}