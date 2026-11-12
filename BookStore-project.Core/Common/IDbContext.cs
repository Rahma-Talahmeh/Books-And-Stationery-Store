using System;
using System.Data.Common;

namespace BookStore_project.Core.Common
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
