using AktivesKochbuch.Data;
using AktivesKochbuch.Interfaces;
using AktivesKochbuch.Models;
using Microsoft.EntityFrameworkCore;

namespace AktivesKochbuch.Repository;

public class RezeptRepository : IRezeptRepository
{
    private readonly ApplicationDbContext _context;

    public RezeptRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Rezept>> GetAll()
    {
        return await _context.Rezepte.ToListAsync();
    }

    public async Task<Rezept> GetByIdAsync(int id)
    {
        return await _context.Rezepte.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(Rezept rezept)
    {
        _context.Add(rezept);
        return Save();
    }

    public bool Update(Rezept rezept)
    {
        _context.Update(rezept);
        return Save();
    }

    public bool Delete(Rezept rezept)
    {
        _context.Remove(rezept);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}