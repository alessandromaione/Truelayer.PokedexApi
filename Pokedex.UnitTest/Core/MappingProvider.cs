using AutoMapper;
using Pokedex.Core.MapperProfiles;

namespace Pokedex.UnitTest.Core
{
    internal class MappingProvider
    {
        internal IMapper GetMapper()
        {
            return GetConfiguration().CreateMapper();
        }

        private MapperConfiguration GetConfiguration()
        {
            var mapperConfig = new MapperConfigurationExpression();
            mapperConfig.AddProfile<AutoMapperProfile>();

            return new MapperConfiguration(mapperConfig);
        }

    }
}
