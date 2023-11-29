using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _mockDatabase.Birds.Where(bird => bird.Id == request.Id).FirstOrDefault()!;

            if (birdToUpdate == null)
            {
                return Task.FromResult<Bird>(null!);
            }
            birdToUpdate.Name = request.BirdToUpdate.Name;
            birdToUpdate.CanFly = request.BirdToUpdate.CanFly;

            return Task.FromResult(birdToUpdate);
        }
    }
}
