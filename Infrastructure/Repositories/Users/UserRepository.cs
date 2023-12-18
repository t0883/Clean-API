using Domain.Models;
using Infrastructure.Database.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly SqlDatabase _sqlDatabase;

        public UserRepository(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                _sqlDatabase.Users.Add(user);
                _sqlDatabase.SaveChanges();

                return await Task.FromResult(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> DeleteUser(Guid userId)
        {
            try
            {
                User userToDelete = await GetUserById(userId);

                _sqlDatabase.Users.Remove(userToDelete);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(userToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a user with Id {userId} from the database", ex);
            }
        }

        public async Task<User> GetUserById(Guid userId)
        {
            try
            {
                User? wantedUser = await _sqlDatabase.Users.FirstOrDefaultAsync(user => user.UserId == userId);

                if (wantedUser == null)
                {
                    throw new Exception($"There is no user with Id {userId} in the database");
                }

                return await Task.FromResult(wantedUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occed while getting a user by Id {userId} from database", ex);
            }
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            try
            {
                _sqlDatabase.Users.Update(updatedUser);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(updatedUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while updating a user by Id {updatedUser.UserId} from database", ex);
            }
        }
    }
}
