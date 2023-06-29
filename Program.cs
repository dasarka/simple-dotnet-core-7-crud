using simple_dotnet_core_7_crud.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseExtension();
builder.AddApiExtension();
builder.AddAuthenticationExtension();
builder.AddSwaggerExtension();
builder.AddMapperExtension();
builder.AddApplicationExtension();
builder.AddHttpExtension();

var app = builder.Build();

app.UseSwaggerExtension();
app.UseHttpExtension();
app.UseAuthenticationExtension();
app.UseApiExtension();

app.Run();
