using LogicApp.Contravts.Users;
using LogicApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;

[Route("Register")]
public class RegisterController : Controller
{
    private readonly UserService _userService;
    private readonly IWebHostEnvironment _appEnvironment;
    public RegisterController(UserService userService, IWebHostEnvironment appEnvironment)
    {
        _userService = userService;
        _appEnvironment = appEnvironment;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisertUserRequest request)
    {
        
        if (await _userService.Register(
                request.UserName,
                request.Password))
        {
            Directory.CreateDirectory(_appEnvironment.WebRootPath + "/Files/" + request.UserName);
            return Redirect("~/Home");
        }
        
        return new OkObjectResult("Такое имя пользователя уже существует.");
    }
}

// Todo: валидация формы регистрации 
