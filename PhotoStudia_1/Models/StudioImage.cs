using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class StudioImage
{
    public int ImageId { get; set; }

    public byte[] Image { get; set; } = null!;

    public int? StudioId { get; set; }

    public virtual Studio? Studio { get; set; }
}
