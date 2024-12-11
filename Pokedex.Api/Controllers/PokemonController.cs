using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Api.Results;
using Pokedex.Core.Abstractions.Services;
using Pokedex.Core.Models;

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

            if(pokemon == null)
            {
                return BadRequest($"Pokemon {pokemonName} not found");
            }

            return Ok(_mapper.Map<Pokemon>(pokemon));
        }
    }
}