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
    public class LoginRepository: ILoginRepository
    {
        private readonly IDbContext dbContext;

        public LoginRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Login Authentication(Login login)
        {
            var p = new DynamicParameters();
            p.Add("USER_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.USER_LOGIN",p,commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
