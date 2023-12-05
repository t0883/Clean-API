using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly SqlDatabase _sqlDatabase;

        public AddDogCommandHandler(MockDatabase mockDatabase, SqlDatabase sqlDatabase)
        {
            _mockDatabase = mockDatabase;
            _sqlDatabase = sqlDatabase;
        }

        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _mockDatabase.Dogs.Add(dogToCreate);
            _sqlDatabase.Dogs.Add(dogToCreate);
            _sqlDatabase.SaveChanges();

            return Task.FromResult(dogToCreate);
        }
    }
}
