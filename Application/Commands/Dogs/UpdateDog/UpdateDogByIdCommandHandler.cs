using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _mockDatabase.Dogs.Where(dog => dog.Id == request.Id).FirstOrDefault()!;

            dogToUpdate.Name = request.DogToUpdate.Name;

            return Task.FromResult(dogToUpdate);
        }
    }
}
