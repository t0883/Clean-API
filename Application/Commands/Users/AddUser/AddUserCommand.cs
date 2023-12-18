using MediatR;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<string>
    {
        public AddUserCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }
    }
}
