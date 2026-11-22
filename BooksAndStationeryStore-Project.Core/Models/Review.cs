using System;
using System.Collections.Generic;

namespace BooksAndStationeryStore_Project.Core.Models;

public partial class Review
{
    public decimal ReviewId { get; set; }

    public decimal ProductId { get; set; }

    public string? CustomerName { get; set; } 

    public int Rating { get; set; }

    public string? Comments { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
