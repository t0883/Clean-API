using Domain.Models;
using Infrastructure.Database.SqlServer;
using MediatR;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        //private readonly MockDatabase _mockDatabase;
        private readonly SqlDatabase _sqlDatabase;


        public GetDogByIdQueryHandler(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _sqlDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            if (wantedDog == null)
            {
                return Task.FromResult<Dog>(null!);
            }
            return Task.FromResult(wantedDog);
        }
    }
}
