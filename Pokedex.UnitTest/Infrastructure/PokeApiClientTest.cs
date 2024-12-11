using Moq;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Core.Models;
using Pokedex.Infrastructure;
using Pokedex.Infrastructure.ExternalClients;

namespace Pokedex.UnitTest.Infrastructure
{
    public class PokeApiClientTest
    {
        private readonly PokeApiClient _pokeApiClient;
        private readonly Mock<IHttpClientWrapper> _httpClientWrapper = new();

        public PokeApiClientTest()
        {
            _pokeApiClient = new PokeApiClient(_httpClientWrapper.Object);
        }

        [Fact]
        public async Task Get_WithInvalidPokemonName_ShouldReturnNull()
        {
            PokemonSpecies? notExistingPokemon = null;

            _httpClientWrapper
                .Setup(s => s.ReadAsync<PokemonSpecies>(It.IsAny<string>()))
                .ReturnsAsync(notExistingPokemon);

            var pokemon = await _pokeApiClient.GetAsync("fakePokemon");

            Assert.Null(pokemon);
        }
    }
}