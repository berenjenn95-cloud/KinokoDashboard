using KinokoBackend.Domain;
using KinokoBackend.Infrastucture.DBContext;
using Microsoft.EntityFrameworkCore;

namespace KinokoBackend.Application.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _db;

        public SongRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Song song)
        {
            _db.Songs.Add(song);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song != null)
            {
                _db.Songs.Remove(song);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Song?> GetByIdAsync(int id)
        {
            return await _db.Songs.FindAsync(id);
        }
        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _db.Songs.ToListAsync();
        }
    }
}
