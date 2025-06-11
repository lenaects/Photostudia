using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Request
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientPhone { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public int? PhotographerId { get; set; }

    public int? ServiceId { get; set; }

    public int? ShootingTypeId { get; set; }

    public DateOnly? ShootingDate { get; set; }

    public int? ServiceTypeId { get; set; }

    public virtual Photographer? Photographer { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ServiceType? ServiceType { get; set; }

    public virtual Typeshooting? ShootingType { get; set; }
}
