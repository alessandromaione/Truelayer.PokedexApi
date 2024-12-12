using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.Abstractions.HttpClients
{
    public interface IFunTranslationsClient
    {
        Task<ApiResult<Translation>> TranslateToYodaAsync(string description);

        Task<ApiResult<Translation>> TranslateToShakespeareAsync(string description);
    }
}
