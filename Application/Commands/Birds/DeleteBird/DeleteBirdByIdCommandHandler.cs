using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _mockDatabase.Birds.Where(bird => bird.Id == request.Id).FirstOrDefault()!;

            if (birdToDelete == null)
            {
                return Task.FromResult<Bird>(null!);
            }

            _mockDatabase.Birds.Remove(birdToDelete);

            return Task.FromResult(birdToDelete);
        }
    }
}
