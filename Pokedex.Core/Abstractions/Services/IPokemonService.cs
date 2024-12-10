using Pokedex.Core.Models;

namespace Pokedex.Core.Abstractions.Services
{
    public interface IPokemonService
    {
        Task<PokemonSpecies> GetAsync(string name);
    }
}