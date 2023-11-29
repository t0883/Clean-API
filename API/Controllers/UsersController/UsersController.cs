using Application.Commands.Users;
using Application.Dtos;
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
        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _mediator.Send(new GetUserTokenQuery(username, password));

            if (user != null)
            {
                return Ok(user.token);
            }

            return NotFound("User not found");

        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {
            if (newUser.Password == string.Empty && newUser.UserName == string.Empty)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(new AddUserCommand(newUser)));
        }
    }
}
