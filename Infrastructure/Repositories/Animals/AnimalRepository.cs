using Domain.Models.Animal;
using Domain.Models.UserAnimal;
using Infrastructure.Database.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Animals
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly SqlDatabase _sqlDatabase;

        public AnimalRepository(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<List<AnimalModel>> GetAllAnimals()
        {
            try
            {
                List<AnimalModel> allAnimals = new List<AnimalModel>();

                var dogs = await _sqlDatabase.Dogs.ToListAsync();

                var birds = await _sqlDatabase.Birds.ToListAsync();

                var cats = await _sqlDatabase.Cats.ToListAsync();

                foreach (var dog in dogs)
                {
                    var animal = new AnimalModel { AnimalId = dog.AnimalId, Name = dog.Name };
                    allAnimals.Add(animal);
                }

                foreach (var bird in birds)
                {
                    var animal = new AnimalModel { AnimalId = bird.AnimalId, Name = bird.Name };
                    allAnimals.Add(animal);
                }

                foreach (var cat in cats)
                {
                    var animal = new AnimalModel { AnimalId = cat.AnimalId, Name = cat.Name };
                    allAnimals.Add(animal);
                }

                return allAnimals;

            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all animals in database", ex);
            }
        }

        public async Task<UserAnimalModel> GetAllAnimalsForUser(Guid Id)
        {
            try
            {
                List<UserAnimalJointTable> searchedAnimals = new List<UserAnimalJointTable>();

                var username = await _sqlDatabase.Users.FirstOrDefaultAsync(x => x.UserId == Id);

                if (username == null)
                {
                    throw new Exception($"There is no user with id {Id} in the database");
                }

                var user = new UserAnimalModel { UserId = Id, Username = username.Username };

                var userAnimals = _sqlDatabase.UserAnimals.Where(user => user.UserId == Id).ToList();

                foreach (var dog in userAnimals)
                {
                    var dogs = await _sqlDatabase.Dogs.FirstOrDefaultAsync(x => x.AnimalId == dog.AnimalId);

                    if (dogs == null)
                    {
                        continue;
                    }

                    var animal = new AnimalModel { AnimalId = dog.AnimalId, Name = dogs.Name };

                    user.Animals.Add(animal);
                    searchedAnimals.Add(dog);
                }

                foreach (var animals in searchedAnimals)
                {
                    userAnimals.Remove(animals);
                }

                foreach (var cat in userAnimals)
                {
                    var cats = await _sqlDatabase.Cats.FirstOrDefaultAsync(x => x.AnimalId == cat.AnimalId);

                    if (cats == null)
                    {
                        continue;
                    }
                    var animal = new AnimalModel { AnimalId = cat.AnimalId, Name = cats.Name };

                    user.Animals.Add(animal);
                }

                foreach (var animals in searchedAnimals)
                {
                    userAnimals.Remove(animals);
                }

                foreach (var bird in userAnimals)
                {
                    var birds = await _sqlDatabase.Birds.FirstOrDefaultAsync(x => x.AnimalId == bird.AnimalId);

                    if (birds == null)
                    {
                        continue;
                    }
                    var animal = new AnimalModel { AnimalId = bird.AnimalId, Name = birds.Name };

                    user.Animals.Add(animal);
                }

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting all animals for user with id {Id}", ex);
            }

        }

        public Task<List<AnimalUserModel>> GetAllAnimalUsers()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserAnimalModel>> GetAllUserAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
