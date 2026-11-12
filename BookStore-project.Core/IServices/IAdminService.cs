using BookStore_project.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_project.Core.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin?> GetAdminByIdAsync(int id);
        Task CreateAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(int id);
        Task<Admin?> AdminLoginAsync(string username, string password);
    }
}