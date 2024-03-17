using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Productphoto
{
    public int PhotoId { get; set; }

    public string? Article { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Product? ArticleNavigation { get; set; }
}
