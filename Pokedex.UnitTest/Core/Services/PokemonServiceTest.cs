using Moq;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using Pokedex.Core.Services;

namespace Pokedex.UnitTest.Core.Services
{
    public class PokemonServiceTest
    {
        private PokemonService _pokemonService;
        private readonly Mock<IPokeApiClient> _pokeApiClientMoq = new();

        public PokemonServiceTest()
        {
            _pokemonService = new PokemonService(_pokeApiClientMoq.Object);
        }

        [Theory]
        [InlineData("ditto")]
        [InlineData("mewtwo")]
        public async Task Get_WithValidPokemonName_ShouldReturnPokemon(string pokemonName)
        {
            var existingPokemon = new PokemonSpecies { Name = pokemonName };

            _pokeApiClientMoq
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(existingPokemon);

            var pokemon = await _pokemonService.GetAsync(pokemonName);

            Assert.NotNull(pokemon);
            Assert.True(pokemon.Name.Equals(existingPokemon.Name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}