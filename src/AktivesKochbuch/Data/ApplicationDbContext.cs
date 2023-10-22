using Microsoft.EntityFrameworkCore;

namespace AktivesKochbuch.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}