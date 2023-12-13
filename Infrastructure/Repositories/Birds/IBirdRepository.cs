using Domain.Models;

namespace Infrastructure.Repositories.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirdsAsync();
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird newBird);
        Task<Bird> UpdateBird(Bird updateBird);
        Task<Bird> DeleteBirdById(Guid id);
    }
}
