using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? PassportSerialNumber { get; set; }

    public int? IdPosition { get; set; }

    public int? IdStatus { get; set; }

    public DateOnly? BirthDate { get; set; }

    public byte[]? Photo { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Returnaction> Returnactions { get; set; } = new List<Returnaction>();
}
