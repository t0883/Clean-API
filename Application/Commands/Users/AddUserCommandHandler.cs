using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly MockDatabase _mockDatabase;

        public AddUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.UserName,
                Password = hashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            _mockDatabase.Users.Add(userToCreate);

            return Task.FromResult(userToCreate);
        }
    }
}
