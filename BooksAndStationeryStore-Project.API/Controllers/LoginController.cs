using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        public IActionResult Authentication([FromBody] Login login)
        {
            var token = loginService.Authentication(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}
