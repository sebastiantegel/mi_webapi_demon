
using Microsoft.AspNetCore.Identity;

namespace ApiWithLoginMiddleware.Models;

public class User : IdentityUser
{
    public string Color { get; set; } = string.Empty;
}