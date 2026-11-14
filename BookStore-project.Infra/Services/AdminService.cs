using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Admin> GetAllAdmin()
        {
            return _adminRepository.GetAllAdmin();
        }

        public Admin GetByAdminId(int id)
        {
            return _adminRepository.GetByAdminId(id);
        }

        public void CreateAdmin(Admin admin)
        {
            _adminRepository.CreateAdmin(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminRepository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int id)
        {
            _adminRepository.DeleteAdmin(id);
        }

        public Admin AdminLogin(string username, string password)
        {
            return _adminRepository.AdminLogin(username, password);
        }
    }
}