using PersonsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/persons", () =>
{
    List<Person> persons = [
        new("Sebastian", 45, true, new("Agatvägen 18", "16860", "Bromma")),
        new("Hanna", 45, true, new("Drottninggatan 1", "110 10", "Stockholm")),
        new("Astrid", 15, false, new("Stopvägen 64", "16460", "Bromma")),
        new("Alvar", 15, false, new("Kungsgatan 10", "111 20", "Stockholm"))
    ];

    // persons[0].Adress.Street = "";
    // persons[0].Adress.City = "";

    return persons;
});

app.Run();
