using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Service
{
   public interface IAdminService
    {
        List<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        void CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
        Admin AdminLogin(Admin admin);
    }
}
