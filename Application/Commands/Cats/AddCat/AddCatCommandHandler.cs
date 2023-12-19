using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public AddCatCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {

            Cat catToCreate = new()
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewCat.Name
            };

            await _catRepository.AddCat(catToCreate);


            return catToCreate;
        }
    }
}
