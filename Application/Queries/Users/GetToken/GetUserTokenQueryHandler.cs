using Domain.Models;
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

        public GetUserTokenQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser.Authorized == true)
            {
                wantedUser.token = GenerateJwtToken();

                return Task.FromResult(wantedUser);
            }

            throw new NotImplementedException();
        }

        public string GenerateJwtToken()
        {
            string secretKey = "wtfisthisshitforatoken";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
