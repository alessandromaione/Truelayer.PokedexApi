using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Pokedex.Core;
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
            services.AddHttpClient(Constants.ApiName.PokeApiClient, (client) =>
            {
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });

            services.AddHttpClient(Constants.ApiName.FunTranslationClient, (client) =>
            {
                client.BaseAddress = new Uri("https://api.funtranslations.com/translate/");
            });

            services.AddTransient<IPokeApiClient, PokeApiClient>();
            services.AddTransient<IFunTranslationsClient, FunTranslationsClient>();

            return services;
        }
    }
}
