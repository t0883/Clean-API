using Application.Queries.Users.GetToken;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var user = await _mediator.Send(new GetUserTokenQuery(username, password));

            if (user != null)
            {
                var token = user.token;
                return Ok(token);
            }

            return NotFound("User not found");

        }




    }
}
