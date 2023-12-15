using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            User userToCreate = new()
            {
                UserId = Guid.NewGuid(),
                Username = request.NewUser.UserName,
                Password = hashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            var createdUser = await _userRepository.AddUser(userToCreate);

            return createdUser;
        }
    }
}
