using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Typeshooting
{
    public int Id { get; set; }

    public string Typeshooting1 { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Profiltypeshooting> Profiltypeshootings { get; } = new List<Profiltypeshooting>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
