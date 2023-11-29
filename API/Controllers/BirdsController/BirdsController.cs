using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BirdsController>
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            var bird = await _mediator.Send(new GetBirdByIdQuery(birdId));

            if (bird == null)
            {
                return NotFound();
            }

            return Ok(bird);
        }

        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            if (newBird.Name == string.Empty)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        [HttpPut]
        [Route("updateBird/{updateBirdId}")]
        public async Task<IActionResult> UpdateBirdById([FromBody] BirdDto birdToUpdate, Guid updateBirdId)
        {
            var bird = await _mediator.Send(new GetBirdByIdQuery(updateBirdId));

            if (bird != null)
            {
                return Ok(await _mediator.Send(new UpdateBirdByIdCommand(birdToUpdate, updateBirdId)));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("deleteBird/{deleteBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deleteBirdId)
        {
            var bird = await _mediator.Send(new GetBirdByIdQuery(deleteBirdId));

            if (bird != null)
            {
                await _mediator.Send(new DeleteBirdByIdCommand(deleteBirdId));
            }

            return NoContent();
        }
    }
}
