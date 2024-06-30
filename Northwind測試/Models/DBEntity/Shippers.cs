using System;
using System.Collections.Generic;

namespace NorthwindControl.Models.DBEntity;

public partial class Shippers
{
    public int ShipperID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
