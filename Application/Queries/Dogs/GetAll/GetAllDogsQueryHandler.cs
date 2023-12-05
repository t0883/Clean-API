using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs
{
    internal sealed class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly SqlDatabase _sqlDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDatabase, SqlDatabase sqlDatabase)
        {
            _mockDatabase = mockDatabase;
            _sqlDatabase = sqlDatabase;

        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDatabase = _mockDatabase.Dogs;
            List<Dog> allDogsFromSqlDatabase = _sqlDatabase.Dogs.ToList();

            return Task.FromResult(allDogsFromSqlDatabase);
        }
    }
}
