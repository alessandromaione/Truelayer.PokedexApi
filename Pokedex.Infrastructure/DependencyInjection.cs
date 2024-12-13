using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core;
using Pokedex.Core.Abstractions.HttpClients;
using Pokedex.Infrastructure.ExternalClients;
using Pokedex.Infrastructure.ExternalClients.Configuration;

namespace Pokedex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
            => services
            .AddClients(configuration);

        private static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            var externalClientConfigs = configuration.GetSection(ExternalClientConfiguration.ExternalClientConfigurationName)
                                                 .Get<ExternalClientConfiguration>()
                                             ?? throw new Exception("ExternalClientConfiguration is not configured. Check the AppSettings.json");

            services.AddHttpClient(Constants.ApiName.PokeApiClient, (client) =>
            {
                client.BaseAddress = new Uri(externalClientConfigs.PokeApiClientUrl);
            });

            services.AddHttpClient(Constants.ApiName.FunTranslationClient, (client) =>
            {
                client.BaseAddress = new Uri(externalClientConfigs.FuntranslationsUrl);
            });

            services.AddTransient<IPokeApiClient, PokeApiClient>();
            services.AddTransient<IFunTranslationsClient, FunTranslationsClient>();

            return services;
        }
    }
}
