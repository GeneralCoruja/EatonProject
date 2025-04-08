using Microsoft.AspNetCore.Mvc;

namespace EatonAPI.Controllers;

public class ReportController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}