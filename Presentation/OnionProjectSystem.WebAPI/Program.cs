using OnionProjectSystem.Persistence;
using OnionProjectSystem.Application;
using OnionProjectSystem.Infrastructure;
using OnionProjectSystem.Mapper;
using OnionProjectSystem.Application.Exceptions;
using Microsoft.OpenApi.Models;
namespace OnionProjectSystem.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var environment = builder.Environment;

            builder.Configuration
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json",optional:false)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json",optional:true);

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddCustomMapper();
            builder.Services.AddLogging();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "OnionProjectSystem WebAPI", Version = "v1", Description ="Onion architecture project API swagger client" });
                c.AddSecurityDefinition("Bearer", new()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandlingMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
