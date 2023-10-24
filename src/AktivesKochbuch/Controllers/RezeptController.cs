using AktivesKochbuch.Data;
using AktivesKochbuch.Interfaces;
using AktivesKochbuch.Models;
using AktivesKochbuch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AktivesKochbuch.Controllers;

public class RezeptController : Controller
{
    private readonly IRezeptRepository _rezeptRepository;
    private readonly IPhotoService _photoService;

    public RezeptController(IRezeptRepository rezeptRepository, IPhotoService photoService)
    {
        _rezeptRepository = rezeptRepository;
        _photoService = photoService;
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
    public async Task<IActionResult> Create(CreateRezeptViewModel rezeptVm)
    {
        if (ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(rezeptVm.Bild);

            var rezept = new Rezept
            {
                RezeptTitel = rezeptVm.RezeptTitel,
                Zubereitung = rezeptVm.Zubereitung,
                RezeptKategorie = rezeptVm.RezeptKategorie,
                Bild = result.Url.ToString()
            };
            _rezeptRepository.Add(rezept);
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", "Der Photouplod ist leider fehlgeschlagen");
        }

        return View(rezeptVm);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var rezept = await _rezeptRepository.GetByIdAsync(id);
        if (rezept == null) 
            return View("Error");

        var rezeptVm = new EditRezeptViewModel
        {
            RezeptTitel = rezept.RezeptTitel,
            Zubereitung = rezept.Zubereitung,
            Url = rezept.Bild,
            RezeptKategorie = rezept.RezeptKategorie
        };

        return View(rezeptVm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditRezeptViewModel rezeptVm)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Bearbeiten des Rezepts fehlgeschlagen");
            return View("Edit", rezeptVm);
        }

        var photoResult = await _photoService.AddPhotoAsync(rezeptVm.Bild);

        var rezept = new Rezept
        {
            Id = id,
            RezeptTitel = rezeptVm.RezeptTitel,
            Zubereitung = rezeptVm.Zubereitung,
            Bild = photoResult.Url.ToString(),
            RezeptKategorie = rezeptVm.RezeptKategorie
        };
        _rezeptRepository.Update(rezept);
        
        return RedirectToAction("Index");
    }

}
    
