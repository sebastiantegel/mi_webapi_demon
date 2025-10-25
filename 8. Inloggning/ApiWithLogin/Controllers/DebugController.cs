
using ApiWithLogin.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithLogin.Controllers;

[ApiController]
[Route("[controller]")]
public class DebugController : ControllerBase
{
    private readonly IdentityContext _context;

    public DebugController(IdentityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

}