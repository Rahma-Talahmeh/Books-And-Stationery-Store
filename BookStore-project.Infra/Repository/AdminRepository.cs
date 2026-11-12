using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;
using System.Data;

namespace BookStore_project.Infra
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDbContext _dbContext;

        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. جلب جميع المشرفين
        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            var result = await _dbContext.Connection.QueryAsync<Admin>(
                "ADMIN_PACKAGE.GetAllAdmins",
                commandType: CommandType.StoredProcedure);
            return result;
        }

        // 2. جلب مشرف معين بواسطة الـ ID
        public async Task<Admin?> GetAdminByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Admin>(
                "ADMIN_PACKAGE.GETADMINBYID",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        // 3. إضافة مشرف جديد
        public async Task CreateAdminAsync(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Username", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Password_Hash", admin.PasswordHash, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Full_Name", admin.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "ADMIN_PACKAGE.CREATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // 4. تعديل بيانات مشرف
        public async Task UpdateAdminAsync(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", admin.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Username", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Password_Hash", admin.PasswordHash, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Full_Name", admin.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "ADMIN_PACKAGE.UPDATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // 5. حذف مشرف
        public async Task DeleteAdminAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "ADMIN_PACKAGE.DELETEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // 6. تسجيل الدخول
        public async Task<Admin?> AdminLoginAsync(string username, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("User_Name", username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Pass", password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Admin>(
                "ADMIN_PACKAGE.ADMIN_LOGIN",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}