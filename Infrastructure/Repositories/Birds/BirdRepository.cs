using Domain.Models;
using Infrastructure.Database.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly SqlDatabase _sqlDatabase;

        public BirdRepository(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<Bird> AddBird(Bird newBird)
        {
            try
            {
                _sqlDatabase.Birds.Add(newBird);
                _sqlDatabase.SaveChanges();
                return await Task.FromResult(newBird);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Bird> DeleteBirdById(Guid id)
        {
            try
            {
                Bird birdToDelete = await GetBirdById(id);

                _sqlDatabase.Birds.Remove(birdToDelete);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(birdToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a bird with Id {id} from the database", ex);
            }
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            try
            {
                return await _sqlDatabase.Birds.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all birds from the database", ex);
            }
        }

        public async Task<Bird> GetBirdById(Guid id)
        {
            try
            {
                Bird? wantedBird = await _sqlDatabase.Birds.FirstOrDefaultAsync(bird => bird.AnimalId == id);

                if (wantedBird == null)
                {
                    throw new Exception($"There was no bird with Id {id} in the database");
                }

                return await Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a bird with Id {id} from database", ex);
            }
        }

        public Task<Bird> UpdateBird(Bird updateBird)
        {
            try
            {
                _sqlDatabase.Birds.Update(updateBird);

                _sqlDatabase.SaveChanges();

                return Task.FromResult(updateBird);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a bird by Id {updateBird.AnimalId} from database", ex);
            }
        }
    }
}
