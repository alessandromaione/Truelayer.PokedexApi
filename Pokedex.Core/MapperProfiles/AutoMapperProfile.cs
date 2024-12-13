using AutoMapper;
using Pokedex.Core.Models;
using Pokedex.Core.Results;

namespace Pokedex.Core.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonSpecies, PokemonResult>()
                .ForMember(dest => dest.Habitat, opt => opt.MapFrom(src => src.Habitat != null ? src.Habitat.Name : string.Empty));
            
            CreateMap(typeof(ApiResult<>), typeof(ApiResult<>));
        }
    }
}