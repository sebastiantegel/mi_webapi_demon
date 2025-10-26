
using ApiWithLoginMiddleware.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithLoginMiddleware.Contexts;

public class IdentityContext : IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions options) : base(options) { }
}