using Application.Commands.UserAnimals.AddConnection;
using Application.Commands.UserAnimals.DeleteConnection;
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
            try
            {
                return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all animals from the database", ex);
            }


        }

        [HttpGet]
        [Route("getAllAnimalsForUserById/{userId}")]
        public async Task<IActionResult> GetAllAnimalsForUserById(Guid userId)
        {
            try
            {
                var guid = _guidValidator.Validate(userId);

                if (!guid.IsValid)
                {
                    return BadRequest(guid.Errors.ConvertAll(errors => errors.ErrorMessage));
                }
                var animals = await _mediator.Send(new GetAllAnimalsByIdQuery(userId));

                if (animals == null)
                {
                    return NotFound();
                }

                return Ok(animals);

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting animal for user with Id {userId}", ex);
            }


        }

        [HttpGet]
        [Route("getAnimalById/{animalId}")]
        public async Task<IActionResult> GetAnimalById(Guid animalId)
        {
            try
            {
                var guid = _guidValidator.Validate(animalId);

                if (!guid.IsValid)
                {
                    return BadRequest();
                }

                var animal = await _mediator.Send(new GetAnimalsByIdQuery(animalId));

                if (animal == null)
                {
                    return NotFound();
                }

                return Ok(animal);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting an animal with Id {animalId}", ex);
            }

        }

        [HttpPost]
        [Route("addNewConnectionBetweenAnimalAndUser")]
        public async Task<IActionResult> AddNewConnectionBetweenAnimalAndUser(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);


                var animalguid = _guidValidator.Validate(animalId);

                if (!userGuid.IsValid || !animalguid.IsValid)
                {
                    return BadRequest();
                }

                var connection = await _mediator.Send(new AddAnimalUserConnectionCommand(userId, animalId));

                return Ok(connection);

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while connection userId {userId} with animalId {animalId}", ex);
            }

        }

        [HttpDelete]
        [Route("deleteConnectionBetweenAnimalAndUser")]
        public async Task<IActionResult> DeleteConnectionBetweenAnimalAndUser(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);

                var animalGuid = _guidValidator.Validate(animalId);

                if (!animalGuid.IsValid || !animalGuid.IsValid)
                {
                    return BadRequest();
                }

                await _mediator.Send(new DeleteAnimalUserConnectionCommand(userId, animalId));

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
