using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }

        public List<Admin> GetAllAdmins()
        {
            return adminRepository.GetAllAdmins();
        }

        public Admin GetAdminById(int id)
        {
            return adminRepository.GetAdminById(id);
        }

        public void CreateAdmin(Admin admin)
        {
            adminRepository.CreateAdmin(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            adminRepository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int id)
        {
            adminRepository.DeleteAdmin(id);
        }

        public Admin AdminLogin(Admin admin)
        {
            return adminRepository.AdminLogin(admin);
        }
    }
}
