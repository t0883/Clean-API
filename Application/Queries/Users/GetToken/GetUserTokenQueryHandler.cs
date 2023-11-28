using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetToken
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, User>
    {
        private readonly MockDatabase _mockDatabase;

        public GetUserTokenQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser.Authorized == true)
            {
                return Task.FromResult(wantedUser);
            }

            throw new NotImplementedException();
        }
    }
}
