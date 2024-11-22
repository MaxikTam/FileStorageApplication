using System.Security.Claims;
using LogicApp.Contravts.Users;
using LogicApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;

[Route("Login")]
public class LoginController : Controller
{
    private readonly UserService _userService;
    public LoginController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginUserRequest request)
    {
        try
        {
            var user = await _userService.Login(request.UserName, request.Password);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult("Ошибка обработки запроса");
        }

        return Redirect("~/Home");
    }
}