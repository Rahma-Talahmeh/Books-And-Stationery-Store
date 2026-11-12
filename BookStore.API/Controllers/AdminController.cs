using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] Admin admin)
        {
            await _adminService.CreateAdminAsync(admin);
            return Ok(new { message = "Admin created successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdmin([FromBody] Admin admin)
        {
            await _adminService.UpdateAdminAsync(admin);
            return Ok(new { message = "Admin updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return Ok(new { message = "Admin deleted successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> AdminLogin([FromBody] Admin loginModel)
        {
            var admin = await _adminService.AdminLoginAsync(loginModel.Username, loginModel.PasswordHash);
            if (admin == null)
                return Unauthorized(new { message = "Invalid username or password" });




            

            return Ok(admin);
        }
    }
}