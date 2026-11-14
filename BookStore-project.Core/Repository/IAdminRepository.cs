
using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmin();
        Admin GetByAdminId(int id);
        void CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
        Admin AdminLogin(string username, string password);
    }
}