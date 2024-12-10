using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Abstractions.Services;
using Pokedex.Core.Models;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService) 
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<PokemonSpecies> GetAsync()
        {
            var pok = await _pokemonService.GetAsync("ditto");

            return pok;
        }
    }
}