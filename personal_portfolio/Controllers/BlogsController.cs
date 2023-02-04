using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personal_portfolio.Models;
using Personal_Portfolio.Models;
using Personal_Portfolio.Services;

namespace Personal_Portfolio.Controllers;

public class BlogsController : Controller
{
    private readonly ILogger<BlogsController> _logger;
    private readonly IBlogsDataRepository<BlogModel> dataRepo;

    public BlogsController(ILogger<BlogsController> logger, IBlogsDataRepository<BlogModel> dataRepo)
    {
        this.dataRepo = dataRepo;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(dataRepo.GetData());
    }

    public IActionResult BlogDetails(string blogTitle)
    {
        var blog = dataRepo.GetData().FirstOrDefault(b => b.title == blogTitle);
        return View(blog);
    }

    public PartialViewResult BlogsListPartial()
    {
        return PartialView("_BlogCardPartialView", dataRepo.GetData());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
