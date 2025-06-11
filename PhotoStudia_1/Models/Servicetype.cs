using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class ServiceType
{
    public int ServiceTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProfilServiceType> ProfilServiceTypes { get; } = new List<ProfilServiceType>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ICollection<Service> Services { get; } = new List<Service>();
}
