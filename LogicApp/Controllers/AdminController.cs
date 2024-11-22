using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogicApp.Controllers;
[Route("Admin")]
public class AdminController : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    [Route("Filters")]
    public IActionResult Filters()
    {
        return View();
    }
    
    [Route("Storage")]
    public IActionResult Storage()
    {
        return View();
    }
    
    [Route("Statistic")]
    public IActionResult Statistic()
    {
        return View();
    }
    
    [Route("Archive")]
    public IActionResult Archive()
    {
        return View();
    }
    
}