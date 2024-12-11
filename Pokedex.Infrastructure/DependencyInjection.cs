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
            services.AddHttpClient("PokeApiClient", (client) =>
            {
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });

            services.AddTransient<IHttpClientWrapper>(ctx =>
            {
                var httpClient = ctx
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient("PokeApiClient");

                return new HttpClientWrapper(httpClient);
            });

            services.AddTransient<IPokeApiClient, PokeApiClient>();

            return services;
        }
    }
}
