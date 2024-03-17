using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Review
{
    public int IdReview { get; set; }

    public string? ClientName { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? Article { get; set; }

    public virtual Product? ArticleNavigation { get; set; }
}
