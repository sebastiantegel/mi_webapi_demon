
using ApiWithLoginMiddleware.Models;
using ApiWithLoginMiddleware.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithLoginMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        User? currentUser = await _userManager.GetUserAsync(User);

        if (currentUser == null)
        {
            return Unauthorized();
        }

        currentUser.Color = request.Color;
        var result = await _userManager.UpdateAsync(currentUser);

        if (result.Succeeded) return Ok();

        return BadRequest(result.Errors);
    }

}