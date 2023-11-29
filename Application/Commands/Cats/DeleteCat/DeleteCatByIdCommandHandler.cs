using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _mockDatabase.Cats.Where(cat => cat.Id == request.Id).FirstOrDefault()!;

            if (catToDelete == null)
            {
                return Task.FromResult<Cat>(null!);
            }

            _mockDatabase.Cats.Remove(catToDelete);

            return Task.FromResult(catToDelete);
        }
    }
}
