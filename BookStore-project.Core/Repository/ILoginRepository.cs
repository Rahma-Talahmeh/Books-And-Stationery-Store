using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_project.Core.Models;
namespace BookStore_project.Core.Repository
{
    public interface ILoginRepository
    {
      public  Login Authintication(Login login);
    }
}
//.