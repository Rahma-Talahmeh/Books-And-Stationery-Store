using BookStore_project.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using BookStore_project.Core.Models;


namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(Login login)
        {
            var token = loginService.Authintication(login);
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
