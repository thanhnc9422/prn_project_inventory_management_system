using System;
using System.Collections.Generic;

namespace ProviderPage.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string? WarehouseName { get; set; }

    public string? Location { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
