using AutoMapper;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Abstractions.Services;
using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiClient _pokeApiClient;
        private readonly IFunTranslationsClient _funTranslationsClient;
        private readonly IMapper _mapper;

        public PokemonService(
            IPokeApiClient pokeApiClient,
            IFunTranslationsClient funTranslationsClient,
            IMapper mapper)
        {
            _pokeApiClient = pokeApiClient;
            _funTranslationsClient = funTranslationsClient;
            _mapper = mapper;
        }

        public async Task<ApiResult<PokemonResult>> GetAsync(string pokemonName)
        {
            var pokemonResult = await _pokeApiClient.GetAsync(pokemonName);

            return _mapper.Map<PokemonResult>(pokemonResult.ApiValue);
        }

        public async Task<ApiResult<PokemonResult>> GetTranslatedAsync(string pokemonName)
        {
            var pokemonResult = await GetAsync(pokemonName);

            if (pokemonResult.IsValid)
            {
                var pokemon = pokemonResult.ApiValue;
                var translationResult = await GetTranslationAsync(pokemon);

                if (translationResult.IsValid)
                {
                    pokemon.Description = translationResult.ApiValue.Contents.Translated;
                }
                else
                {
                    return translationResult.Exception;
                }
            }

            return pokemonResult;
        }

        private Task<ApiResult<Translation>> GetTranslationAsync(PokemonResult pokemon)
        {
            if (pokemon.IsCave || pokemon.IsLegendary)
            {
                return _funTranslationsClient.TranslateToYodaAsync(pokemon.Description);
            }
            else
            {
                return _funTranslationsClient.TranslateToShakespeareAsync(pokemon.Description);
            }
        }
    }
}