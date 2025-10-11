using HttpResponses.Models;
using HttpResponses.Models.Requests;

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

List<Person> persons = [
    new("Sebastian", 45, true, new("Agatvägen 18", "168 60", "Bromma")),
    new("Hanna", 45, true, new("Drottninggatan 1", "111 10", "Stockholm")),
    new("Astrid", 15, false, new("Stopvägen 64", "164 80", "Bromma")),
    new("Alvar", 15, false, new("Kungsgatan 10", "111 11", "Stockholm"))
];

app.MapGet("/persons", () =>
{
    return Results.Ok(persons);
});

app.MapGet("/persons/{id}", (string id) =>
{
    try
    {
        Person? found = persons.FirstOrDefault((p) => p.Id == id);

        if (found == null)
        {
            return Results.NotFound("Hittade inte personen du sökte efter");
        }

        return Results.Ok(found);
    }
    catch
    {
        return Results.InternalServerError("Hoppsan! Ett fel inträffade");
    }
});

app.MapPost("/persons", (CreatePersonRequest request) =>
{
    try
    {
        Person newPerson = new(request.Name, request.Age, request.IsMarried, new(request.Street, request.Zip, request.City));
        persons.Add(newPerson);

        return Results.Created("/persons", newPerson);
    }
    catch
    {
        return Results.InternalServerError("Hoppsan igen!");
    }
});

app.Run();
