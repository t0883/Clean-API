using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
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

        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        [HttpPut]
        [Route("updateCat/{updateCatId}")]
        public async Task<IActionResult> UpdateCatById([FromBody] CatDto catToUpdate, Guid updateCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatByIdCommand(catToUpdate, updateCatId)));
        }

        [HttpDelete]
        [Route("deleteCat/{deleteCatId}")]
        public async Task<IActionResult> DeleteCat(Guid deleteCatId)
        {
            await _mediator.Send(new DeleteCatByIdCommand(deleteCatId));

            return NoContent();
        }
    }
}
