using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Users.GetToken
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, string>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public GetUserTokenQueryHandler(MockDatabase mockDatabase, JwtTokenGenerator jwtTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<string> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser == null)
            {
                return Task.FromResult<string>(null!);
            }

            var token = _jwtTokenGenerator.GenerateJwtToken(wantedUser);

            return Task.FromResult(token);

        }
    }
}
