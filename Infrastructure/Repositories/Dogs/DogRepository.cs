using Domain.Models;
using Infrastructure.Database.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly SqlDatabase _sqlDatabase;
        //Implement ILogger

        public DogRepository(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            try
            {
                //List<Dog> allDogsFromDatabase = _sqlDatabase.Dogs.ToList();



                //return await Task.FromResult(obejct);

                return await _sqlDatabase.Dogs.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid dogId)
        {
            try
            {
                List<Dog> allDogsFromDatabase = _sqlDatabase.Dogs.ToList();

                Dog wantedDog = allDogsFromDatabase.FirstOrDefault(dog => dog.Id == dogId)!;

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a dog by Id {dogId} from database", ex);
            }
        }
    }
}
