using AktivesKochbuch.Data;
using Microsoft.AspNetCore.Mvc;

namespace AktivesKochbuch.Controllers;

public class RezeptController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public RezeptController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var rezepte = _context.Rezepte.ToList();
        return View(rezepte);
    }
}