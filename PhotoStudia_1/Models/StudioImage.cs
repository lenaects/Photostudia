using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class StudioImage
{
    public int ImageId { get; set; }

    public int? StudioId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Studio? Studio { get; set; }
}
