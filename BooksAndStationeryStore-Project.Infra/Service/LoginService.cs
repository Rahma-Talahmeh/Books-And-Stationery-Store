using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
    public class LoginService: ILoginService
    {

        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }


        public string Authentication(Login login)
        {
            var result = loginRepository.Authentication(login);
            if (result == null) { return null; }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTrainingJWTSecretKey2026Secure!"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, result.Username),
            new Claim(ClaimTypes.Role, result.Roleid.ToString())
        };

                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
        }
    }
}
