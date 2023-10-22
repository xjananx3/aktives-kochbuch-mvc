using AktivesKochbuch.Models;
using Microsoft.EntityFrameworkCore;

namespace AktivesKochbuch.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Rezept> Rezepte { get; set; }
    public DbSet<Vorschlag> Vorschläge { get; set; }
}