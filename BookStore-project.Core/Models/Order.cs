using System;
using System.Collections.Generic;
using BookStore_project.Core.Models;
namespace BookStore_project.Core.Models;

public partial class Order
{
    public decimal OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string DeliveryAddress { get; set; } = null!;

    public string? OrderStatus { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
