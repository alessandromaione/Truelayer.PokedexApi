using Pokedex.Api.Handlers;

namespace Pokedex.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
            => services
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails()
            .AddSwaggerGen();
    }
}
