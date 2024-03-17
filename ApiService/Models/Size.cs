using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Size
{
    public int IdSize { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Productsize> Productsizes { get; set; } = new List<Productsize>();
}
