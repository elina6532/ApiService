using System;
using System.Collections.Generic;

namespace ApiService.Models;

public partial class Product
{
    public string Article { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public string? Status { get; set; }

    public int? IdCategory { get; set; }

    public int? IdManufacturer { get; set; }

    public int? IdDiscount { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Discount? IdDiscountNavigation { get; set; }

    public virtual Manufacturer? IdManufacturerNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Productphoto> Productphotos { get; set; } = new List<Productphoto>();

    public virtual ICollection<Productsize> Productsizes { get; set; } = new List<Productsize>();

    public virtual ICollection<Returnrequest> Returnrequests { get; set; } = new List<Returnrequest>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
