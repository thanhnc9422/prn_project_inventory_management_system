using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public int? StaffId { get; set; }

    public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

    public virtual Staff? Staff { get; set; }
}
