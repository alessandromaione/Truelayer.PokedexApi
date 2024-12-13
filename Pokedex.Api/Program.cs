using Pokedex.Core;
using Pokedex.Infrastructure;

namespace Pokedex.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();

            builder
                .Services
                .AddApi()
                .AddCore()
                .AddInfrastructure(configuration);

            var app = builder.Build();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseExceptionHandler();

            app.MapControllers();

            app.Run();
        }
    }
}
