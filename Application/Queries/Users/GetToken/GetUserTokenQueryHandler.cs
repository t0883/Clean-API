using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetToken
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, User>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public GetUserTokenQueryHandler(MockDatabase mockDatabase, JwtTokenGenerator jwtTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<User> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser.Authorized == true)
            {
                wantedUser.token = _jwtTokenGenerator.GenerateJwtToken(wantedUser);

                return Task.FromResult(wantedUser);
            }

            throw new NotImplementedException();
        }
    }
}
