using System;
using System.Collections.Generic;

namespace BooksAndStationeryStore_Project.Core.Models;

public partial class Author
{
    public decimal AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? Bio { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
