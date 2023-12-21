﻿using Application.Commands.UserAnimals;
using Application.Queries.Animals.GetAll;
using Application.Queries.Animals.GetAllAnimalsForUser;
using Application.Queries.Animals.GetById;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnimalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;

        public AnimalsController(IMediator mediator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
        }

        [HttpGet]
        [Route("getAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
        }

        [HttpGet]
        [Route("getAllAnimalsForUserById/{userId}")]
        public async Task<IActionResult> GetAllAnimalsForUserById(Guid userId)
        {
            var animals = await _mediator.Send(new GetAllAnimalsByIdQuery(userId));

            return Ok(animals);
        }

        [HttpGet]
        [Route("getAnimalById/{animalId}")]
        public async Task<IActionResult> GetAnimalById(Guid animalId)
        {
            var animal = await _mediator.Send(new GetAnimalsByIdQuery(animalId));

            return Ok(animal);
        }

        [HttpPost]
        [Route("addNewConnectionBetweenAnimals")]
        public async Task<IActionResult> AddNewConnectionBetweenAnimals(Guid userId, Guid animalId)
        {
            var connection = await _mediator.Send(new AddAnimalUserConnectionCommand(userId, animalId));

            return Ok(connection);
        }
    }
}
