namespace Pokedex.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
            => services
            .AddSwaggerGen();
    }
}
