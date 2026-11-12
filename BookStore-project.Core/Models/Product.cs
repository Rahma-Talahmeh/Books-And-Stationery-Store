using System;
using System.Collections.Generic;
//using BookStore_project.Core.Models;
//using BookStore_project.Core.IServices;
namespace BookStore_project.Core.Models;

public partial class Product
{
    public decimal ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? CoverImage { get; set; }

    public decimal Price { get; set; }

    public decimal StockQuantity { get; set; }

    public string? Isbn { get; set; }

    public decimal? PublicationYear { get; set; }

    public string? ProductType { get; set; }

    public bool? IsFeatured { get; set; }

    public bool? IsNewArrival { get; set; }

    public bool? IsBestSeller { get; set; }

    public decimal CategoryId { get; set; }

    public decimal? AuthorId { get; set; }

    public decimal? PublisherId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Publisher? Publisher { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
