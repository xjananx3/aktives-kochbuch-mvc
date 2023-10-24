using AktivesKochbuch.Data;
using AktivesKochbuch.Interfaces;
using AktivesKochbuch.Models;
using Microsoft.AspNetCore.Mvc;

namespace AktivesKochbuch.Controllers;

public class RezeptController : Controller
{
    private readonly IRezeptRepository _rezeptRepository;

    public RezeptController(IRezeptRepository rezeptRepository)
    {
        _rezeptRepository = rezeptRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var rezepte = await _rezeptRepository.GetAll();
        return View(rezepte);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var rezept = await _rezeptRepository.GetByIdAsync(id);
        return View(rezept);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Rezept rezept)
    {
        if (!ModelState.IsValid)
        {
            return View(rezept);
        }
        _rezeptRepository.Add(rezept);
        return RedirectToAction("Index");
    }
    
}