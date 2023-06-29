
namespace simple_dotnet_core_7_crud.Extensions
{
    public static class ApiExtension
    {
        public static WebApplicationBuilder AddApiExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static WebApplication UseApiExtension(this WebApplication app)
        {
            app.MapControllers();

            return app;
        }
    }
}