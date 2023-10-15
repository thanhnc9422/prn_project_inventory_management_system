using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string? ProviderName { get; set; }

    public string? ProviderAddress { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
