using CFL.WebApi.Helpers;
using CFL.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CFL.WebApi.Controllers;

public class AccountController : Controller
{
    private IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody]AuthRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}