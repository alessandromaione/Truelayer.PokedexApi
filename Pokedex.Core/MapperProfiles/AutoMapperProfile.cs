using AutoMapper;
using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonSpecies, PokemonResult>();
            CreateMap(typeof(ApiResult<>), typeof(ApiResult<>));
        }
    }
}