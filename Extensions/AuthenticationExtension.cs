using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace simple_dotnet_core_7_crud.Extensions
{
    public static class AuthenticationExtension
    {
        public static WebApplicationBuilder AddAuthenticationExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                        builder.Configuration.GetSection("AppSettings:Token").Value!
                        )),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return builder;
        }

        public static WebApplication UseAuthenticationExtension(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}