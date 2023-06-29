
namespace simple_dotnet_core_7_crud.Extensions
{
    public static class HttpExtension
    {
        public static WebApplicationBuilder AddHttpExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            return builder;
        }

        public static WebApplication UseHttpExtension(this WebApplication app)
        {
            app.UseHttpsRedirection();

            return app;
        }
    }
}