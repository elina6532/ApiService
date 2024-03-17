using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Manufacturer
{
    public int IdManufacturer { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
