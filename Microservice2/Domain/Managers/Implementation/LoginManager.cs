using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Model;
using Microservice2.Model.Authentication;
using Microservice2.Model.Dto;
using Microsoft.Extensions.Options;

namespace Microservice2.Domain.Managers.Implementation
{
    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;

        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
        }

        public async Task<LoginResponse> Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var loginResponse = new LoginResponse()
            {
                AccessToken = accessToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime()
            };

            return loginResponse;
        }
    }
}
