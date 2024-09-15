using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}