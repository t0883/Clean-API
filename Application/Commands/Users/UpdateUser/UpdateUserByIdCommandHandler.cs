using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            User userToUpdate = await _userRepository.GetUserById(request.Id);

            if (userToUpdate == null)
            {
                return null!;
            }

            AnimalModel animalToAddToUser = new AnimalModel
            {
                Name = "Sten",
                AnimalId = new Guid()
            };
            /*
            userToUpdate.Username = request.UserToUpdate.UserName;
            userToUpdate.Role = request.UserToUpdate.Role;
            userToUpdate.Authorized = request.UserToUpdate.Authorized;
            userToUpdate.Animals.Add(animalToAddToUser);
            */
            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}
