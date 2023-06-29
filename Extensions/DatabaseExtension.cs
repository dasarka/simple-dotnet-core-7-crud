
namespace simple_dotnet_core_7_crud.Extensions
{
    public static class DatabaseExtension
    {
        public static WebApplicationBuilder AddDatabaseExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            return builder;
        }
    }
}