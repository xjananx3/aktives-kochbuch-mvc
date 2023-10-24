using System.ComponentModel.DataAnnotations;
using AktivesKochbuch.Data.Enum;

namespace AktivesKochbuch.ViewModels;

public class CreateRezeptViewModel
{
    [Key]
    public int Id { get; set; }
    public string RezeptTitel { get; set; }
    public string Zubereitung { get; set; }
    public RezeptKategorie RezeptKategorie { get; set; }
    public IFormFile? Bild { get; set; }
}