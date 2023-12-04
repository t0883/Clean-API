using Application.Commands.Users;
using Application.Dtos;
using Application.Queries.Users.GetToken;
using Application.Validators.User;
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
        internal readonly UserValidator _userValidator;

        public UsersController(IMediator mediator, UserValidator userValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
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
            var userValidator = _userValidator.Validate(newUser);

            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddUserCommand(newUser)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
