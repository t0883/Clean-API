using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User userToCreate = new()
            {
                UserId = Guid.NewGuid(),
                Username = request.UserName,
                Password = hashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            await _userRepository.AddUser(userToCreate);

            var message = "";

            return message;
        }
    }
}
