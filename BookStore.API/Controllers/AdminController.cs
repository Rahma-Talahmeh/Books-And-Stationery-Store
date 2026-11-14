using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
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
        public List<Admin> GetAllAdmin()
        {
            return _adminService.GetAllAdmin();
        }

        [HttpGet("getById/{id}")]
        public Admin GetByAdminId(int id)
        {
            return _adminService.GetByAdminId(id);
        }

        [HttpPost]
        public void CreateAdmin(Admin admin)
        {
            _adminService.CreateAdmin(admin);
        }

        [HttpPut]
        public void UpdateAdmin(Admin admin)
        {
            _adminService.UpdateAdmin(admin);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteAdmin(int id)
        {
            _adminService.DeleteAdmin(id);
        }
    }
}