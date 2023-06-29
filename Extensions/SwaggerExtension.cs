using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace simple_dotnet_core_7_crud.Extensions
{
    public static class SwaggerExtension
    {
        public static WebApplicationBuilder AddSwaggerExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "'Standard Authorization header using the Bearer scheme. Example 'bearer {token}'",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return builder;
        }

        public static WebApplication UseSwaggerExtension(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}