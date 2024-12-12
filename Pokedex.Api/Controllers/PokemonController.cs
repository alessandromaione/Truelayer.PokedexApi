using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Abstractions.Services;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonService pokemonService, IMapper mapper) 
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> GetAsync(string pokemonName)
        {
            var pokemon = await _pokemonService.GetAsync(pokemonName);

            if(!pokemon.IsValid)
            {
                throw pokemon.Exception;
            }
            else if (pokemon.IsNotFound)
            {
                return BadRequest($"Pokemon {pokemonName} not found");
            }

            return Ok(pokemon.ApiValue);
        }

        [HttpGet("translated/{pokemonName}")]
        public async Task<IActionResult> GetTranslatedAsync(string pokemonName)
        {
            var pokemon = await _pokemonService.GetTranslatedAsync(pokemonName);

            if (!pokemon.IsValid)
            {
                throw pokemon.Exception;
            }
            else if (pokemon.IsNotFound)
            {
                return BadRequest($"Pokemon {pokemonName} not found");
            }

            return Ok(pokemon.ApiValue);
        }

    }
}