using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public GetCatByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.Cats.Where(cat => cat.AnimalId == request.Id).FirstOrDefault()!;

            if (wantedCat == null)
            {
                return Task.FromResult<Cat>(null!);
            }

            return Task.FromResult(wantedCat);
        }
    }
}
