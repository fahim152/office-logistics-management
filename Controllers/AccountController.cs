using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Utils;


[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly JwtUtils _jwtUtils;

    public AccountController(UserManager<User> userManager, JwtUtils jwtUtils)
    {
        _userManager = userManager;
        _jwtUtils = jwtUtils;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new User 
        { 
            UserName = model.Email, 
            Email = model.Email,
            Name = model.Name,  
            Type = model.Type  
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            var token = _jwtUtils.GenerateToken(user);
            return Ok(new { token });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
       var user = await _userManager.FindByNameAsync(model.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = _jwtUtils.GenerateToken(user);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}
