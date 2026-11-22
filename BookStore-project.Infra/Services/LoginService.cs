using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_project.Infra.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }
        public string Authintication(Login login)
        {
            var result = loginRepository.Authintication(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTrainingJWTSecretKey2026Secure!"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List <Claim>
                {
                    new Claim (ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.Role, result.Roleid.ToString())
                };
                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                     signingCredentials: signinCredentials,
                     expires: DateTime.Now.AddHours(24)
                   );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
        }
    }
}
//.