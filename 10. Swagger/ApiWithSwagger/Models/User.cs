
using Microsoft.AspNetCore.Identity;

namespace ApiWithSwagger.Models;

public class User : IdentityUser
{
    public string Color { get; set; } = string.Empty;
}