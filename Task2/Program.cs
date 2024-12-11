using Microsoft.AspNetCore.Authentication;
using Task2.Services;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
