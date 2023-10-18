using System;
using System.Collections.Generic;

namespace ProviderPage.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Role? Role { get; set; }
}
