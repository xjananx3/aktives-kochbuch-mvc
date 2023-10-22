using Microsoft.AspNetCore.Mvc;

namespace AktivesKochbuch.Controllers;

public class VorschlagController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}