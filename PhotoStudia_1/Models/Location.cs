using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Location
{
    public int Locationid { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Imagepath { get; set; }

    public virtual ICollection<Service> Services { get; } = new List<Service>();
}
