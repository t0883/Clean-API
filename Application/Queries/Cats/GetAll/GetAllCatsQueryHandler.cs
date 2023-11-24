using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAll
{
    internal sealed class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllCatsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        Task<List<Cat>> IRequestHandler<GetAllCatsQuery, List<Cat>>.Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromMockDatabase = _mockDatabase.Cats;
            return Task.FromResult(allCatsFromMockDatabase);
        }
    }
}
