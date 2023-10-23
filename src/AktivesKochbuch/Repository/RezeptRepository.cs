using AktivesKochbuch.Data;
using AktivesKochbuch.Interfaces;
using AktivesKochbuch.Models;

namespace AktivesKochbuch.Repository;

public class RezeptRepository : IRezeptRepository
{
    private readonly ApplicationDbContext _context;

    public RezeptRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<IEnumerable<Rezept>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Rezept> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public bool Add(Rezept rezept)
    {
        throw new NotImplementedException();
    }

    public bool Update(Rezept rezept)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Rezept rezept)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}