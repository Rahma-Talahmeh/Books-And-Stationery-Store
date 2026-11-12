using System;
using System.Collections.Generic;

namespace BookStore_project.Core.Models;

public partial class Review
{
    public decimal ReviewId { get; set; }

    public decimal ProductId { get; set; }

    public string CustomerName { get; set; } = null!;

    public bool Rating { get; set; }

    public string? Comments { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
