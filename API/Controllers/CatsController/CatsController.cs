using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        internal readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all cats from database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        // Get a cat by Id
        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(catId)));
        }
    }
}
