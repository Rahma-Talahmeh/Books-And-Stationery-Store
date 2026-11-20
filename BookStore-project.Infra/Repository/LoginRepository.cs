using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext dBContext;

        public LoginRepository(IDbContext _dbContext)
        {
            dBContext = _dbContext;
        }

        public Login Authintication(Login login)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dBContext.Connection.Query<Login>(
                "Login_Package.User_Login",
                p,
                commandType: CommandType.StoredProcedure
            );


            return result.FirstOrDefault();
        }
    }
}