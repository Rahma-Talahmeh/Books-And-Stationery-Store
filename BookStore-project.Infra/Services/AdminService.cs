using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_project.Infra.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
    {
        return await _adminRepository.GetAllAdminsAsync();
    }

    public async Task<Admin?> GetAdminByIdAsync(int id)
    {
        return await _adminRepository.GetAdminByIdAsync(id);
    }

    public async Task CreateAdminAsync(Admin admin)
    {
        await _adminRepository.CreateAdminAsync(admin);
    }

    public async Task UpdateAdminAsync(Admin admin)
    {
        await _adminRepository.UpdateAdminAsync(admin);
    }

    public async Task DeleteAdminAsync(int id)
    {
        await _adminRepository.DeleteAdminAsync(id);
    }

    public async Task<Admin?> AdminLoginAsync(string username, string password)
    {
        return await _adminRepository.AdminLoginAsync(username, password);
    }
}