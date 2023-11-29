using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
            //return Ok("GET ALL DOGS");
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            var dog = await _mediator.Send(new GetDogByIdQuery(dogId));

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // Create a new dog 
        [Authorize]
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            if (newDog.Name == string.Empty)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new AddDogCommand(newDog)));
        }

        // Update a specific dog
        [Authorize]
        [HttpPut]
        [Route("updateDog/{updateDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto dogToUpdate, Guid updateDogId)
        {
            if (dogToUpdate.Name == string.Empty)
            {
                return BadRequest();
            }

            var dog = await _mediator.Send(new GetDogByIdQuery(updateDogId));

            if (dog != null)
            {
                return Ok(await _mediator.Send(new UpdateDogByIdCommand(dogToUpdate, updateDogId)));
            }

            return NotFound();
        }

        // Delete a specific dog
        [Authorize]
        [HttpDelete]
        [Route("deleteDog/{deleteDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deleteDogId)
        {
            var dog = await _mediator.Send(new GetDogByIdQuery(deleteDogId));

            if (dog != null)
            {
                await _mediator.Send(new DeleteDogByIdCommand(deleteDogId));
            }

            return NoContent();
        }
    }
}
