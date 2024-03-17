using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public string? Article { get; set; }

    public int? IdClient { get; set; }

    public int? Quantity { get; set; }

    public DateTime? AddDate { get; set; }

    public virtual Product? ArticleNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
