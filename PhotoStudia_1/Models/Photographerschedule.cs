using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Photographerschedule
{
    public int Scheduleid { get; set; }

    public int Photographerid { get; set; }

    public DateOnly Date { get; set; }

    public TimeSpan Starttime { get; set; }

    public TimeSpan Endtime { get; set; }

    public virtual Photographer Photographer { get; set; } = null!;
}
