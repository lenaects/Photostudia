using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class StudioService
{
    public int Id { get; set; }

    public int? ServiceId { get; set; }

    public int? StudioId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Studio? Studio { get; set; }
}
