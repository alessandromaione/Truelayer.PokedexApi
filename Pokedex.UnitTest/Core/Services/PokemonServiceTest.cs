using AutoMapper;
using Moq;
using Pokedex.Core;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using Pokedex.Core.Results;
using Pokedex.Core.Services;

namespace Pokedex.UnitTest.Core.Services
{
    public class PokemonServiceTest
    {
        private PokemonService _pokemonService;
        private readonly Mock<IPokeApiClient> _pokeApiClientMoq = new();
        private readonly Mock<IFunTranslationsClient> _funTranslationsClientMoq = new();
        private readonly IMapper _mapper;

        public PokemonServiceTest()
        {
            _mapper = new MappingProvider().GetMapper();

            _pokemonService = new PokemonService(
                _pokeApiClientMoq.Object,
                _funTranslationsClientMoq.Object,
                _mapper);
        }

        [Theory]
        [InlineData("ditto")]
        [InlineData("mewtwo")]
        public async Task Get_WithValidPokemonName_ShouldReturnPokemon(string pokemonName)
        {
            var existingPokemon = new PokemonSpecies { Name = pokemonName };
            var result = new ApiResult<PokemonSpecies>(existingPokemon);

            _pokeApiClientMoq
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(result);

            var pokemon = await _pokemonService.GetAsync(pokemonName);

            Assert.NotNull(pokemon);
            Assert.True(pokemon.IsValid);
            Assert.True(pokemon.ApiValue.Name.Equals(existingPokemon.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public async Task Get_WithInvalidPokemonName_ShouldReturnInvalidResult()
        {
            var result = new ApiResult<PokemonSpecies>();

            _pokeApiClientMoq
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(result);

            var pokemon = await _pokemonService.GetAsync("fakePokemon");

            Assert.False(pokemon.IsValid);
        }

        [Fact]
        public async Task GetTranlated_WithValidPokemonCave_ShouldReturn_YodaDescription()
        {
            var pokemonName = "ditto";

            var existingPokemon = new PokemonSpecies
            {
                Name = pokemonName,
                Habitat = new Habitat { Name = Constants.Habitat.Cave },
            };
            var pokemonResult = new ApiResult<PokemonSpecies>(existingPokemon);

            var translation = new Translation
            {
                Contents = new Contents { Translated = "translated yoda content" },
            };
            var translationResult = new ApiResult<Translation>(translation);

            _pokeApiClientMoq
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(pokemonResult);

            _funTranslationsClientMoq
                .Setup(s => s.TranslateToYodaAsync(It.IsAny<string>()))
                .ReturnsAsync(translationResult);

            var pokemon = await _pokemonService.GetTranslatedAsync(pokemonName);

            Assert.True(pokemon.IsValid);
            Assert.True(translationResult.IsValid);
            _funTranslationsClientMoq.Verify(s => s.TranslateToYodaAsync(It.IsAny<string>()), Times.Once);

            Assert.Equal(pokemon.ApiValue.Description, translationResult.ApiValue.Contents.Translated);
        }

        [Fact]
        public async Task GetTranlated_NoCaveAndNoLegendary_ShouldReturn_ShakespeareDescription()
        {
            var pokemonName = "ditto";

            var existingPokemon = new PokemonSpecies
            {
                Name = pokemonName,
                IsLegendary = false,
            };
            var pokemonResult = new ApiResult<PokemonSpecies>(existingPokemon);

            var translation = new Translation
            {
                Contents = new Contents { Translated = "translated Shakespeare content" },
            };
            var translationResult = new ApiResult<Translation>(translation);

            _pokeApiClientMoq
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(pokemonResult);

            _funTranslationsClientMoq
                .Setup(s => s.TranslateToShakespeareAsync(It.IsAny<string>()))
                .ReturnsAsync(translationResult);

            var pokemon = await _pokemonService.GetTranslatedAsync(pokemonName);

            Assert.True(pokemon.IsValid);
            Assert.True(translationResult.IsValid);
            _funTranslationsClientMoq.Verify(s => s.TranslateToShakespeareAsync(It.IsAny<string>()), Times.Once);

            Assert.Equal(pokemon.ApiValue.Description, translationResult.ApiValue.Contents.Translated);
        }
    }
}