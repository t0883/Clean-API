using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _mockDatabase.Birds.Where(bird => bird.Id == request.Id).FirstOrDefault()!;

            if (wantedBird == null)
            {
                return Task.FromResult<Bird>(null!);
            }

            return Task.FromResult(wantedBird);
        }
    }
}
