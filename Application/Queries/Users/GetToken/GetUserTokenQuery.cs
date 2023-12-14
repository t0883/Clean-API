using MediatR;

namespace Application.Queries.Users.GetToken
{
    public class GetUserTokenQuery : IRequest<string>
    {
        public GetUserTokenQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public bool IsAuthorized { get; }
    }
}
