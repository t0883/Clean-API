﻿using Domain.Models;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> GetUserById(Guid id);
    }
}
