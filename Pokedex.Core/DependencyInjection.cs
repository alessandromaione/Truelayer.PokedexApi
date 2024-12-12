using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Abstractions.Services;
using Pokedex.Core.MapperProfiles;
using Pokedex.Core.Services;

namespace Pokedex.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
            .AddServices()
            .AddAutoMapper(typeof(AutoMapperProfile));

        private static IServiceCollection AddServices(this IServiceCollection services)
            => services
            .AddTransient<IPokemonService, PokemonService>();
    }
}
