using System;
using System.Collections.Generic;

namespace BookStore_project.Core.Models;

public partial class VwTopRatedBook
{
    public decimal ProductId { get; set; }

    public string Title { get; set; } = null!;

    public decimal? AverageRating { get; set; }

    public decimal? TotalReviews { get; set; }
}
