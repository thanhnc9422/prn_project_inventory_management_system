using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class DeliveryDetail
{
    public int DeliveryDetailId { get; set; }

    public int? DeliveryQuantity { get; set; }

    public DateTime? ExpectedDate { get; set; }

    public DateTime? ActualDate { get; set; }

    public int? DeliveryId { get; set; }

    public int? ProductId { get; set; }

    public decimal? SalePrice { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
