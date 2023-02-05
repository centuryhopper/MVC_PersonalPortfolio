using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.Models;
using Personal_Portfolio.Services;

namespace Personal_Portfolio.Controllers;

public class SkillsController : Controller
{
    private readonly ILogger<SkillsController> _logger;
    private readonly ISkillsDataRepository<string> dataRepo;

    public class DataToPassToView
    {
        public IEnumerable<string> programmingLanguages { get; set; } = null!;
        public IEnumerable<string> techs { get; set; } = null!;
        public IEnumerable<string> pythonLibraries { get; set; } = null!;
        public IEnumerable<string> linuxTools { get; set; } = null!;
    }

    public SkillsController(ILogger<SkillsController> logger, ISkillsDataRepository<string> dataRepository)
    {
        _logger = logger;
        this.dataRepo = dataRepository;
    }

    public IActionResult Index()
    {
        var skillsData = dataRepo.GetData();

        var dataToPassToView = new DataToPassToView
        {
            programmingLanguages = skillsData["programmingLanguages"],
            techs = skillsData["techs"],
            pythonLibraries = skillsData["pythonLibraries"],
            linuxTools = skillsData["linuxTools"],
        };

        return View(dataToPassToView);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
