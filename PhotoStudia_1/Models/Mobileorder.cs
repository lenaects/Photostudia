using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Mobileorder
{
    public int Mobileorderid { get; set; }

    public int Orderid { get; set; }

    public string Eventaddress { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
