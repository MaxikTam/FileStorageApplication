using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;
[Route("Admin")]
public class AdminController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}