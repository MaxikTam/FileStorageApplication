using LogicApp.Contravts.Users;
using LogicApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;

[Route("Register")]
public class RegisterController : Controller
{
    private readonly UserService _userService;

    public RegisterController(UserService userService)
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
    public async Task<IActionResult> Register(RegisertUserRequest request)
    {
        await _userService.Register(
            request.UserName,
            request.Password);
        
        return new OkResult();
    }
}

// Todo: валидация формы регистрации 
