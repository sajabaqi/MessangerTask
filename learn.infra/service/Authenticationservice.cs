using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra.service
{
    public class Authenticationservice : IAuthenticationservice
    {
        private readonly IAuthentication authen;
        public Authenticationservice(IAuthentication authintication)
        {
            this.authen = authintication;
        }
        public string Authentication_jwt(login_api login)
        {
            var result = authen.auth(login);

            if (result == null)
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email, result.username),
                    new Claim(ClaimTypes.Role, result.rolename),
                    new Claim(ClaimTypes.Name, 1.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }

        public string Authentication_jwt(BlockF_dto BlockF_)
        {
            throw new NotImplementedException();
        }
    }
}
