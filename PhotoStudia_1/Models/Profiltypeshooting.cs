using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Profiltypeshooting
{
    public int Id { get; set; }

    public int? Profilphotographerid { get; set; }

    public int Typeshootingid { get; set; }

    public virtual Profilphotographer? Profilphotographer { get; set; }

    public virtual Typeshooting Typeshooting { get; set; } = null!;
}
