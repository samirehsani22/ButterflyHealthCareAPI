using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ButterflyHealthCareAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register Swagger services
            builder.Services.AddEndpointsApiExplorer();  // Required for OpenAPI (Swagger) generation
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Butterfly Healthcare API",
                    Version = "v1",
                    Description = "Calculate numbers based on user input"
                });

                // Get the XML comments file path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Include the XML comments in Swagger
                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();  // Enable Swagger middleware
                app.UseSwaggerUI();  // Enable Swagger UI middleware
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => Results.Redirect("/swagger"))
               .WithOpenApi(operation => new OpenApiOperation
               {
                   Summary = "Redirects to Swagger UI for easy access to the API. This should be removed during production",
                   Description = "Redirects the root URL (/) to the Swagger UI for easy access to the API documentation."
               });

            app.Run();
        }
    }
}
