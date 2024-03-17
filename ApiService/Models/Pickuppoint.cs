using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Pickuppoint
{
    public int IdPickupPoint { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
