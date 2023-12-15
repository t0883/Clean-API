using Domain.Models.Animal;
using Infrastructure.Database.SqlServer;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Users.GetAllAnimals
{
    public class GetAllAnimalsByIdQueryHandler : IRequestHandler<GetAllAnimalsByIdQuery, List<AnimalModel>>
    {
        private readonly IDogRepository _dogRepository;
        private readonly SqlDatabase _sqlDatabase;

        public GetAllAnimalsByIdQueryHandler(IDogRepository dogRepository, SqlDatabase sqlDatabase)
        {
            _dogRepository = dogRepository;
            _sqlDatabase = sqlDatabase;
        }
        public async Task<List<AnimalModel>> Handle(GetAllAnimalsByIdQuery request, CancellationToken cancellationToken)
        {
            List<AnimalModel> animalModels = new List<AnimalModel>();

            var animals = await _dogRepository.GetAllDogsAsync();

            var wantedAnimals = _sqlDatabase.UserAnimals.Where(x => x.UserId == request.Id).ToList();

            foreach (var animal in animals)
            {
                foreach (var userAnimal in wantedAnimals)
                {
                    if (animal.AnimalId == userAnimal.AnimalId)
                    {
                        var x = new AnimalModel { AnimalId = userAnimal.AnimalId, Name = animal.Name };
                        animalModels.Add(x);
                    }

                }
            }

            return animalModels;
        }
    }
}
