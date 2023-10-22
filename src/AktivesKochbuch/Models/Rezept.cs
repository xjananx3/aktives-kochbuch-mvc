using System.ComponentModel.DataAnnotations;
using AktivesKochbuch.Data.Enum;

namespace AktivesKochbuch.Models;

public class Rezept
{
    [Key] 
    public int Id { get; set; }
    public string RezeptTitel { get; set; }
    public string Zubereitung { get; set; }
    public RezeptKategorie RezeptKategorie { get; set; }
}