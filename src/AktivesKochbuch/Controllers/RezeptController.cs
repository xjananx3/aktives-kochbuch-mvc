using Microsoft.AspNetCore.Mvc;

namespace AktivesKochbuch.Controllers;

public class RezeptController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}