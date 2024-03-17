using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Orderdetail
{
    public int IdDetail { get; set; }

    public int? IdOrder { get; set; }

    public int? Quantity { get; set; }

    public decimal? Cost { get; set; }

    public string? Article { get; set; }

    public string? ReturnStatus { get; set; }

    public virtual Product? ArticleNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}
