using BooksAndStationeryStore_Project.Core.Common;
using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Repository
{
   public class AdminRepository:IAdminRepository
    {
        private readonly IDbContext _dbContext; 

        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Admin> GetAllAdmins()
        {
            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "ADMIN_PACKAGE.GetAllAdmins",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Admin GetAdminById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "ADMIN_PACKAGE.GETADMINBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateAdmin(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Username", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Password_Hash", admin.PasswordHash, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Full_Name", admin.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ADMIN_PACKAGE.CREATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateAdmin(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", admin.AdminId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Username", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Password_Hash", admin.PasswordHash, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Full_Name", admin.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ADMIN_PACKAGE.UPDATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteAdmin(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ADMIN_PACKAGE.DELETEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public Admin AdminLogin(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("User_Name", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Pass", admin.PasswordHash, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "ADMIN_PACKAGE.ADMIN_LOGIN",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
