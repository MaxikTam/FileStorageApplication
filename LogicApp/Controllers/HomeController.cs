using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogicApp.Models;
using LogicApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LogicApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FileService _fileService;
    
    public HomeController(ILogger<HomeController> logger, FileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }
    
    public IActionResult Index() 
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    [Route("Home/Upload")]
    public IActionResult Upload(IFormFile uploadedFile)
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    [Route("Home/Upload")]
    public async Task<IActionResult> UploadFile(IFormFile uploadedFile)
    {
        if (uploadedFile == null) return BadRequest("Непрочатан файл!");

        var user = HttpContext.User.Identity;
        if(user == null || user.Name == null)  return BadRequest("Провал авторизации!");

        try
        {
            if (await _fileService.Upload(uploadedFile, user.Name))
            {
                // todo: Сделать запсь в журнал 
                return new RedirectToRouteResult(
                    new RouteValueDictionary(new
                        {
                            action = "Download",
                            controller = "Home"
                        }
                    ));
            }
            else
            {
                return BadRequest("Ошибка скачивания");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка скачивания");
        }
    }
    
    [HttpGet]
    [Authorize]
    [Route("Home/Download")]
    public IActionResult Download()
    {
        var user = HttpContext.User.Identity;
        if (user == null) return BadRequest("Ошибка аунфикации");

        try
        {
            var fileNames = _fileService.GetFileNamesByUserName(user.Name);
            return View(fileNames);
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка вполнения операции");
        }
    }
    
    [HttpGet]
    [Authorize]
    [Route("Home/DownloadFile")]
    public IActionResult DownloadFile(string fileName)
    {
        var user = HttpContext.User.Identity;
        if (user == null) return BadRequest("Ошибка аунфикации");
        
        try
        {
            var filePath = _fileService.GetFilePathByName(user.Name, fileName);
            var fileType = "text/plain";
            return PhysicalFile(filePath, fileType);
            // todo: Сделать запсь в журнал 
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка скачивания файлов");
        }
    }
    
    [Route("Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}