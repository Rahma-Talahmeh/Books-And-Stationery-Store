using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpGet]
        public List<Admin> GetAllAdmins()
        {
            return adminService.GetAllAdmins();
        }

        [HttpPost]
        public void CreateAdmin(Admin admin)
        {
            adminService.CreateAdmin(admin);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateAdmin(Admin admin)
        {
            adminService.UpdateAdmin(admin);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteAdmin(int id)
        {
            adminService.DeleteAdmin(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Admin GetAdminById(int id)
        {
            return adminService.GetAdminById(id);
        }

        
    }
}
