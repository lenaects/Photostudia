using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Studio
{
    public int StudioId { get; set; }

    public string Address { get; set; } = null!;

    public decimal PricePerHour { get; set; }

    public virtual ICollection<StudioImage> StudioImages { get; } = new List<StudioImage>();

    public virtual ICollection<StudioService> StudioServices { get; } = new List<StudioService>();
}
