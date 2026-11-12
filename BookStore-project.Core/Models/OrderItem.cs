using System;
using System.Collections.Generic;
using BookStore_project.Core.Models;
namespace BookStore_project.Core.Models;

public partial class OrderItem
{
    public decimal OrderItemId { get; set; }

    public decimal OrderId { get; set; }

    public decimal ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
