using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class ProfilServiceType
{
    public int Id { get; set; }

    public int ProfilphotographerId { get; set; }

    public int ServiceTypeId { get; set; }

    public virtual Profilphotographer Profilphotographer { get; set; } = null!;

    public virtual ServiceType ServiceType { get; set; } = null!;
}
