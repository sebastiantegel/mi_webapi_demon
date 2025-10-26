
using System.Text.Json.Serialization;
using ApiWithLoginMiddleware.Models;
using ApiWithLoginMiddleware.Contexts;
using ApiWithLoginMiddleware.Repositories;
using ApiWithLoginMiddleware.Services;
using Microsoft.EntityFrameworkCore;
using ApiWithLoginMiddleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("MyTestDatabase"));
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseInMemoryDatabase("MyTestDatabase"));

builder.Services.AddIdentityApiEndpoints<User>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthorization();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    var identityContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();
    identityContext.Database.EnsureCreated();
}

app.MapIdentityApi<User>();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ColorCheckMiddleware>();

app.MapControllers();

app.Run();