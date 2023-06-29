using simple_dotnet_core_7_crud.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseExtension();
builder.AddApiExtension();
builder.AddSwaggerExtension();
builder.AddMapperExtension();
builder.AddServiceExtension();


builder.AddHttpExtension();

var app = builder.Build();

app.UseSwaggerExtension();
app.UseHttpExtension();
app.UseAuthenticationExtension();
app.UseApiExtension();

app.Run();
