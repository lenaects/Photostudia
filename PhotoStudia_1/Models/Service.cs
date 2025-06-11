using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public int? ServiceTypeId { get; set; }

    public virtual ICollection<MobileService> MobileServices { get; } = new List<MobileService>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ServiceType? ServiceType { get; set; }

    public virtual StudioService? StudioService { get; set; }
}
