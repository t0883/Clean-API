using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(DogDto deleteDog, Guid id)
        {
            DeleteDog = deleteDog;
            Id = id;
        }

        public DogDto DeleteDog { get; }
        public Guid Id { get; }

    }

}

