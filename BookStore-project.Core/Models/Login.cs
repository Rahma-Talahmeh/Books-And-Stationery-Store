using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_project.Core.Models
{
    public class Login
    {
        public decimal LoginId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal Roleid { get; set; }
    }
}
//.