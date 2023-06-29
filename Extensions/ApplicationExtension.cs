using simple_dotnet_core_7_crud.Common.HttpProfile;
using simple_dotnet_core_7_crud.Services.CharacterService;
using simple_dotnet_core_7_crud.Services.WeaponService;

namespace simple_dotnet_core_7_crud.Extensions
{
    public static class ApplicationExtension
    {
        public static WebApplicationBuilder AddApplicationExtension(this WebApplicationBuilder builder)
        {
            builder.AddServiceExtension();
            builder.AddProfileExtension();

            return builder;
        }
        private static WebApplicationBuilder AddServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IWeaponService, WeaponService>();

            return builder;
        }

        private static WebApplicationBuilder AddProfileExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IHttpProfile, HttpProfile>();

            return builder;
        }
    }
}