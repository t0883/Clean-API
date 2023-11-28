using Application.Queries.Users.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Route("LogIn")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            return Ok(await _mediator.Send(new GetUserTokenQuery(username, password)));
        }

    }
}
