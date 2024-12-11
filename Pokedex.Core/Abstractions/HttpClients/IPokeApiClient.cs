using Pokedex.Core.Models;

namespace Pokedex.Core.Abstractions.HttpClients
{
    public interface IPokeApiClient
    {
        Task<PokemonSpecies?> GetAsync(string name);
    }
}
