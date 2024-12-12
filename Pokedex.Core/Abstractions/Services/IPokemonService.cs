using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.Abstractions.Services
{
    public interface IPokemonService
    {
        Task<ApiResult<PokemonResult>> GetAsync(string name);

        Task<ApiResult<PokemonResult>> GetTranslatedAsync(string pokemonName);
    }
}