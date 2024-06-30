using System;
using System.Collections.Generic;

namespace NorthwindControl.Models.DBEntity;

public partial class Order_Subtotals
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
