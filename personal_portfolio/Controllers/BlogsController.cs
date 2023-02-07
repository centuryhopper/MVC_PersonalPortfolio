using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

    // public override void OnActionExecuted(ActionExecutedContext filterContext)
    // {
    //     // Perform any processing that needs to be done after the action has executed
    //     base.OnActionExecuted(filterContext);

    //     Console.WriteLine("Initted blog index page");
    // }

    public IActionResult Index(string isNewest)
    {
        ViewBag.SortBy = isNewest == "Newest" ? "Oldest" : "Newest";
        return View(dataRepo.Sort(ViewBag.SortBy
        == "Newest"));
    }

    public IActionResult BlogDetails(string blogTitle)
    {
        var blog = dataRepo.GetData().FirstOrDefault(b => b.title == blogTitle);
        return View(blog);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
