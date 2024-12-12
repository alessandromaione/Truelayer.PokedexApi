using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.Abstractions.HttpClients
{
    public interface IPokeApiClient
    {
        Task<ApiResult<PokemonSpecies>> GetAsync(string name);
    }
}
