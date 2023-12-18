using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Users.GetAllAnimals
{
    public class GetAllAnimalsByIdQuery : IRequest<List<AnimalModel>>
    {
        public GetAllAnimalsByIdQuery(Guid userId)
        {
            Id = userId;
        }
        public Guid Id { get; }
    }
}
