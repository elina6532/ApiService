using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Discount
{
    public int IdDiscount { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
