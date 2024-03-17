using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Returnrequest
{
    public int RequestId { get; set; }

    public int? OrderId { get; set; }

    public string? Article { get; set; }

    public string? Reason { get; set; }

    public DateOnly? RequestDate { get; set; }

    public string? Status { get; set; }

    public virtual Product? ArticleNavigation { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Returnaction> Returnactions { get; set; } = new List<Returnaction>();
}
