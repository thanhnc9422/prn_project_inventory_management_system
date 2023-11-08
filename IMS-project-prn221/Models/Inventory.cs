using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? QuantityAvaiable { get; set; }

    public int? ProductId { get; set; }

    public int? WarehouseId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
