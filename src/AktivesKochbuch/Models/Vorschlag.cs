using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AktivesKochbuch.Models;

public class Vorschlag
{
    [Key] 
    public int Id { get; set; }
    public DateOnly Wochentag { get; set; }
    [ForeignKey("Rezept")]
    public int RezeptId { get; set; }
    public int AnzahlVorschläge { get; set; }
    public ICollection<Rezept> Rezeptvorschläge { get; set; }
}