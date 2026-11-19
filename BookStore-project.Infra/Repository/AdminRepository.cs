
using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;
namespace BookStore_project.Infra.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDbContext _dbContext;

        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Admin> GetAllAdmin()
        {
            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "Admin_Package.GetAllAdmins",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Admin GetByAdminId(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "Admin_Package.GetAdminById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreateAdmin(Admin admin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Username", admin.USERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Password_Hash", admin.PASSWORD_HASH, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Full_Name", admin.FULL_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.EMAIL, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Admin_Package.CREATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateAdmin(Admin admin)
        {
            var p = new DynamicParameters();
            p.Add("ID", admin.ADMIN_ID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Username", admin.USERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Password_Hash", admin.PASSWORD_HASH, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Full_Name", admin.FULL_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email", admin.EMAIL, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Admin_Package.UPDATEADMIN",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteAdmin(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Admin_Package.DELETEADMIN",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public Admin AdminLogin(string username, string password)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Admin> result = _dbContext.Connection.Query<Admin>(
                "Login_Package.User_Login",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}