using Domain.Models.UserAnimal;

namespace Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task<List<AnimalUserModel>> GetAllAnimals();
        Task<UserAnimalModel> GetAllAnimalsForUser(Guid id);
        Task<AnimalUserModel> GetAnimalById(Guid id);
    }
}
