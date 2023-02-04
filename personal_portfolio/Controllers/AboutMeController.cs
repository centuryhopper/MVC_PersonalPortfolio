using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personal_portfolio.Models;
using Personal_Portfolio.Models;


namespace Personal_Portfolio.Controllers;

public class AboutMeController : Controller
{
    private readonly ILogger<AboutMeController> _logger;

    public AboutMeController(ILogger<AboutMeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
