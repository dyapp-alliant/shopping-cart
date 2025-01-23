using ShoppingCart.Contracts;
using ShoppingCart.Services;

namespace ShoppingCart 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registering as a singleton for DEMO ONLY to keep cart items in memory
            // In a real situation where the API was serving distributed requests, I would use another implementation (Redis, in-memory cache, etc)
            builder.Services.AddSingleton<ITerminal, Terminal>();
            builder.Services.AddScoped<IProductList, ProductList>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
