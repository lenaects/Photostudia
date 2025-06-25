using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Portfolio
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public int Profilphotographerid { get; set; }

    public virtual Profilphotographer Profilphotographer { get; set; } = null!;
}
