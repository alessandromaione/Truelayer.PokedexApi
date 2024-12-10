using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Infrastructure.ExternalClients;

namespace Pokedex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
            => services
            .AddClients();

        private static IServiceCollection AddClients(this IServiceCollection services)
        {
             services.AddHttpClient<IPokeApiClient, PokeApiClient>();

            return services;
        }
    }
}
