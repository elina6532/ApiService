using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Returnaction
{
    public int ActionId { get; set; }

    public int? RequestId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? ActionDate { get; set; }

    public string? ActionDescription { get; set; }

    public string? ActionStatus { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Returnrequest? Request { get; set; }
}
