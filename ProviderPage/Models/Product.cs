using System;
using System.Collections.Generic;

namespace ProviderPage.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductCategory { get; set; }

    public bool? Refrigerated { get; set; }

    public decimal? PackedHeight { get; set; }

    public decimal? PackedWidth { get; set; }

    public decimal? PackedDepth { get; set; }

    public int? ProviderId { get; set; }

    public decimal? OriginPrice { get; set; }

    public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Provider? Provider { get; set; }
}
