
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Birds.GetAll
{
    internal sealed class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly SqlDatabase _sqlDatabase;

        public GetAllBirdsQueryHandler(MockDatabase mockDatabase, SqlDatabase sqlDatabase)
        {
            _mockDatabase = mockDatabase;
            _sqlDatabase = sqlDatabase;
        }

        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromMockDatabase = _mockDatabase.Birds;
            List<Bird> allBirdsFromSqlDatabase = _sqlDatabase.Birds.ToList();
            return Task.FromResult(allBirdsFromSqlDatabase);
        }
    }
}
