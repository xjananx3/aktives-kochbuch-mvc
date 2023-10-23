using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AktivesKochbuch.Data.Enum;

namespace AktivesKochbuch.Models;

public class Rezept
{
    [Key] 
    public int Id { get; set; }
    public string RezeptTitel { get; set; }
    public string Zubereitung { get; set; }
    public RezeptKategorie RezeptKategorie { get; set; }
    public string? Bild { get; set; }
    [ForeignKey("Benutzer")]
    public int? BenutzerId { get; set; }
    public Benutzer? Benutzer { get; set; }
}