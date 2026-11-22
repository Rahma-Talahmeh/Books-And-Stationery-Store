using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Common
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }
    }
}
