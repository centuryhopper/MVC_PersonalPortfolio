using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.Models;
using Personal_Portfolio.Services;

namespace Personal_Portfolio.Controllers;

public class ProjectsController : Controller
{
    private readonly ILogger<ProjectsController> logger;
    private readonly IProjectsDataRepository<ProjectCardModel> dataRepo;
    public IEnumerable<ProjectCardModel> projects;

    public ProjectsController(ILogger<ProjectsController> logger, IProjectsDataRepository<ProjectCardModel> dataRepo)
    {
        this.logger = logger;
        this.dataRepo = dataRepo;
        projects = dataRepo.GetData();
    }

    public IActionResult Index(string searchTerm)
    {
        projects = dataRepo.Search(searchTerm);
        return View(projects);
    }

    // get by default so the header really isn't needed but shown for clarity
    [HttpGet]
    public PartialViewResult SearchUsers(string searchTerm)
    {
        projects = dataRepo.Search(searchTerm);
        return PartialView("_ProjectsListView", projects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
