using simple_dotnet_core_7_crud.Services.CharacterService;
using simple_dotnet_core_7_crud.Services.WeaponService;

namespace simple_dotnet_core_7_crud.Extensions
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IWeaponService, WeaponService>();

            return builder;
        }
    }
}