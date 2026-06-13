using KinokoBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace KinokoBackend.Infrastucture.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs => Set<Song>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
