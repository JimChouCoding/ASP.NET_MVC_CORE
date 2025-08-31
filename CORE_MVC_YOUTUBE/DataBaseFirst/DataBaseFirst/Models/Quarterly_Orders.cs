using System;
using System.Collections.Generic;

namespace DataBaseFirst.Models;

public partial class Quarterly_Orders
{
    public string? CustomerID { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
