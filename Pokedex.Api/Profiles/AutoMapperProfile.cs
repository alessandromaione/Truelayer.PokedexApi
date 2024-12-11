using AutoMapper;
using Pokedex.Api.Results;
using Pokedex.Core.Models;

namespace Pokedex.Api.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonSpecies, Pokemon>();
        }
    }
}