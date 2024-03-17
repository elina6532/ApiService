using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdClient { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdPickupPoint { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalCost { get; set; }

    public string? Status { get; set; }

    public string? ReturnStatus { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Pickuppoint? IdPickupPointNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Returnrequest> Returnrequests { get; set; } = new List<Returnrequest>();
}
