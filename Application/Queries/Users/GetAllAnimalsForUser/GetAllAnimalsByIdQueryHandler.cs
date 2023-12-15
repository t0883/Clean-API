using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Users.GetAllAnimals
{
    public class GetAllAnimalsByIdQueryHandler : IRequestHandler<GetAllAnimalsByIdQuery, List<AnimalModel>>
    {
        private readonly IDogRepository _dogRepository;

        public GetAllAnimalsByIdQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<AnimalModel>> Handle(GetAllAnimalsByIdQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogs = await _dogRepository.GetAllDogsAsync();

            List<AnimalModel> animalModels = new List<AnimalModel>();

            foreach (Dog dog in allDogs)
            {
                var requestedAnimal = new AnimalModel { Name = dog.Name, AnimalId = dog.AnimalId };
                animalModels.Add(requestedAnimal);
            }

            return animalModels;
        }
    }
}
