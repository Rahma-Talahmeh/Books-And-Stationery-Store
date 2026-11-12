using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin?> GetAdminByIdAsync(int id);
        Task CreateAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(int id);
        Task<Admin?> AdminLoginAsync(string username, string password);
    }
}