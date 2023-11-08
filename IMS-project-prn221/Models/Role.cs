﻿using System;
using System.Collections.Generic;

namespace IMS_project_prn221.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
