using System;
using System.Collections.Generic;

namespace BookStore_project.Core.Models;

public partial class VwSalesByCategory
{
    public string CategoryName { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
