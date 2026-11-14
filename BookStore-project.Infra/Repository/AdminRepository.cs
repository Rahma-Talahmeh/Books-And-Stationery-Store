
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
            parameters.Add("Admin_Name", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Admin_Package.CREATEADMIN",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateAdmin(Admin admin)
        {
            var p = new DynamicParameters();
            p.Add("ID", admin.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Admin_Name", admin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);

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