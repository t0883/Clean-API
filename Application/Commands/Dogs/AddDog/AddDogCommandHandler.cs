﻿using Application.Validators.Dog;
using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;

        public AddDogCommandHandler(IDogRepository dogRepository, DogValidator validator)
        {
            _dogRepository = dogRepository;
            _dogValidator = validator;
        }
        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {

            Dog dogToCreate = new()
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewDog.Name
            };


            var createdDog = await _dogRepository.AddDog(dogToCreate, request.NewDog.Id);


            return createdDog;
        }

    }
}
