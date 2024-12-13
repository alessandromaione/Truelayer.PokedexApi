using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.Abstractions.Services
{
    public interface IPokemonService
    {
        /// <summary>
        /// Get a Pokemon.
        /// </summary>
        /// <param name="name">Pokemon name to retrieve</param>
        /// <returns>An <see cref="PokemonResult"/>.</returns>
        Task<ApiResult<PokemonResult>> GetAsync(string name);

        /// <summary>
        /// Get a pokemon with a description translated in Yoda or Shakespeare format.
        /// </summary>
        /// <param name="pokemonName">Pokemon name to retrieve.</param>
        /// <returns>An <see cref="PokemonResult"/>.</returns>
        Task<ApiResult<PokemonResult>> GetTranslatedAsync(string pokemonName);
    }
}