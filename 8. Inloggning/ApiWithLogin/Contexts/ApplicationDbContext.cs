
using ApiWithLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithLogin.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
    public DbSet<Adress> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string adressId1 = Guid.NewGuid().ToString();
        string adressId2 = Guid.NewGuid().ToString();

        modelBuilder.Entity<Adress>().HasData([
            new("Agatvägen 18", "16860", "Bromma") { Id = adressId1 },
            new("Stopvägen 64", "16480", "Bromma") { Id = adressId2 },
        ]);

        modelBuilder.Entity<Person>().HasData([
            new("Sebastian", 45, true) { Id = "11111111-1111-1111-1111-111111111111" },
            new("Hanna", 45, true) { Id = "22222222-2222-2222-2222-222222222222" },
            new("Astrid", 15, false) { Id = "33333333-3333-3333-3333-333333333333" },
            new("Alvar", 15, false) { Id = "44444444-4444-4444-4444-444444444444" }
        ]);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Adresses)
            .WithMany(a => a.People)
            .UsingEntity(j => j.HasData([
                new { PeopleId = "11111111-1111-1111-1111-111111111111", AdressesId = adressId1},
                new { PeopleId = "11111111-1111-1111-1111-111111111111", AdressesId = adressId2},
                new { PeopleId = "22222222-2222-2222-2222-222222222222", AdressesId = adressId1},
                new { PeopleId = "22222222-2222-2222-2222-222222222222", AdressesId = adressId2},
                new { PeopleId = "33333333-3333-3333-3333-333333333333", AdressesId = adressId1},
                new { PeopleId = "44444444-4444-4444-4444-444444444444", AdressesId = adressId1},
            ]));

        base.OnModelCreating(modelBuilder);
    }
}