namespace Pokedex.Infrastructure.ExternalClients.Configuration
{
    public class ExternalClientConfiguration
    {
        public static readonly string ExternalClientConfigurationName = "ExternalClient";

        public string PokeApiClientUrl { get; set; }

        public string FuntranslationsUrl { get; set; }
    }
}
