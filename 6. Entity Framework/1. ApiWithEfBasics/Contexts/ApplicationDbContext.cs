
using ApiWithEfBasics.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEfBasics.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData([
            new("Sebastian", 45, true) { Id = "11111111-1111-1111-1111-111111111111" },
            new("Hanna", 45, true) { Id = "22222222-2222-2222-2222-222222222222" },
            new("Astrid", 15, false) { Id = "33333333-3333-3333-3333-333333333333" },
            new("Alvar", 15, false) { Id = "44444444-4444-4444-4444-444444444444" }
        ]);
    }
}