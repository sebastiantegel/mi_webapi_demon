
using ApiWithEfOneToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEfOneToMany.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
    public DbSet<Adress> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Adress)
            .WithMany(a => a.People)
            .HasForeignKey(p => p.AdressId);

        string adressId = Guid.NewGuid().ToString();

        modelBuilder.Entity<Adress>().HasData([
            new("Agatvägen 18", "16860", "Bromma") { Id = adressId }
        ]);

        modelBuilder.Entity<Person>().HasData([
            new("Sebastian", 45, true) { Id = "11111111-1111-1111-1111-111111111111", AdressId = adressId },
            new("Hanna", 45, true) { Id = "22222222-2222-2222-2222-222222222222", AdressId = adressId },
            new("Astrid", 15, false) { Id = "33333333-3333-3333-3333-333333333333", AdressId = adressId },
            new("Alvar", 15, false) { Id = "44444444-4444-4444-4444-444444444444", AdressId = adressId }
        ]);

        base.OnModelCreating(modelBuilder);
    }
}