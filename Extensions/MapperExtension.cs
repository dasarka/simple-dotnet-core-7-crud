using AutoMapper;

namespace simple_dotnet_core_7_crud.Extensions
{
    public static class MapperExtension
    {
        public static WebApplicationBuilder AddMapperExtension(this WebApplicationBuilder builder)
        {

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            return builder;
        }
    }
}