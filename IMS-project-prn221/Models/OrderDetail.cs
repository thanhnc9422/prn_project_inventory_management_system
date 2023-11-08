using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderQuantity { get; set; }

    public DateTime? ExpectedDate { get; set; }

    public DateTime? ActualDate { get; set; }

    public int? ProductId { get; set; }

    public int? WarehouseId { get; set; }

    public decimal? TotalPayment { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? ProviderId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Provider? Provider { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
