using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Client
{
    public int Clientid { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
