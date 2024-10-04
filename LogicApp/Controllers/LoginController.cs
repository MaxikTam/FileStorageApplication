using LogicApp.Contravts.Users;
using LogicApp.Services;
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
        string token = "";
        try
        {
            token = await _userService.Login(request.Name, request.Password);
        }
        catch (Exception ex)
        {
            return new OkResult();
        }
        
        return new OkObjectResult(token);
    }
    
}