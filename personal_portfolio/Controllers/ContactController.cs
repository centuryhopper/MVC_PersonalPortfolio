using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.Models;
using Personal_Portfolio.Services;

namespace Personal_Portfolio.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> logger;
    private readonly IContactsDataRepository<ContactMeModel> dataRepo;

    public ContactController(ILogger<ContactController> logger, IContactsDataRepository<ContactMeModel> dataRepo)
    {
        this.logger = logger;
        this.dataRepo = dataRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> SaveContact(ContactMeModel model)
    {
        logger.LogWarning($"{model}");
        TempData["message"] = "Thank you! Your message has been sent!";
        await this.dataRepo.PostDataAsync(model);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
