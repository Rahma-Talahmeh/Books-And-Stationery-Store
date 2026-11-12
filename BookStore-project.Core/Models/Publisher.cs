using System;
using System.Collections.Generic;

namespace BookStore_project.Core.Models;

public partial class Publisher
{
    public decimal PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
