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
            return Ok(await _mediator.Send(new GetBirdByIdQuery(birdId)));
        }
    }
}
