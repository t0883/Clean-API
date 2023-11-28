using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetToken
{
    public class GetUserTokenQuery : IRequest<User>
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
