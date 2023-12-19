using Domain.Models;

namespace Infrastructure.Repositories.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCatsAsync();
        Task<Cat> GetCatById(Guid id);
        Task<Cat> AddCat(Cat newCat);
        Task<Cat> UpdateCat(Cat updateCat);
        Task<Cat> DeleteCatById(Guid id);
    }
}
