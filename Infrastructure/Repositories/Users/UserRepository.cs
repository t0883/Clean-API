using Domain.Models;
using Infrastructure.Database.SqlServer;

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

        public Task<User> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
