using KinokoBackend.Domain;

namespace KinokoBackend.Application.Repository
{
    public interface ISongRepository
    {
        Task AddAsync(Song song);
        Task DeleteAsync(int id);
        Task<Song?> GetByIdAsync(int id);
    }
}
