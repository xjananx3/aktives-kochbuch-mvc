using AktivesKochbuch.Models;

namespace AktivesKochbuch.Interfaces;

public interface IRezeptRepository
{
    Task<IEnumerable<Rezept>> GetAll();
    Task<Rezept> GetByIdAsync(int id);
    bool Add(Rezept rezept);
    bool Update(Rezept rezept);
    bool Delete(Rezept rezept);
    bool Save();
}