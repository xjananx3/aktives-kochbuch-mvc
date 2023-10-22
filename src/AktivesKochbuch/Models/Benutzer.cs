using System.ComponentModel.DataAnnotations;

namespace AktivesKochbuch.Models;

public class Benutzer
{
    [Key]
    public int Id { get; set; }
    public string Benutzername { get; set; }
    public ICollection<Rezept>? Rezepte { get; set; }
    public ICollection<Vorschlag>? RezeptVorschläge { get; set; }
}