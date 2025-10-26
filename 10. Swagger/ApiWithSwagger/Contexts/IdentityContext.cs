
using ApiWithSwagger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSwagger.Contexts;

public class IdentityContext : IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions options) : base(options) { }
}