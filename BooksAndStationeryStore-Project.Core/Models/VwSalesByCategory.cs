using System;
using System.Collections.Generic;

namespace BooksAndStationeryStore_Project.Core.Models;

public partial class VwSalesByCategory
{
    public string CategoryName { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
