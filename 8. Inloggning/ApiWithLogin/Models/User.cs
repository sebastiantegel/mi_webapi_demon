
using Microsoft.AspNetCore.Identity;

namespace ApiWithLogin.Models;

public class User : IdentityUser
{
    public string Color { get; set; } = string.Empty;
}