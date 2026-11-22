using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_project.Core.Models;
namespace BookStore_project.Core.IServices
{
    public interface ILoginService
    {
        public string Authintication(Login login);
    }
}
//.