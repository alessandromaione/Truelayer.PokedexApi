using Pokedex.Core;
using Pokedex.Infrastructure;

namespace Pokedex.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder
                .Services
                .AddApi()
                .AddCore()
                .AddInfrastructure();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
