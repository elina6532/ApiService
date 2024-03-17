using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Productsize
{
    public int IdProductSize { get; set; }

    public string? Article { get; set; }

    public int? IdSize { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? ArticleNavigation { get; set; }

    public virtual Size? IdSizeNavigation { get; set; }
}
