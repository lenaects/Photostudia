using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class MobileService
{
    public int Id { get; set; }

    public int? ServiceId { get; set; }

    public decimal? Price { get; set; }

    public decimal RadiusFromKm { get; set; }

    public decimal RadiusToKm { get; set; }

    public virtual Service? Service { get; set; }
}
