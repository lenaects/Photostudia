using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Profilphotographer
{
    public int Id { get; set; }

    public int Pfotographerid { get; set; }

    public string Description { get; set; } = null!;

    public int Experience { get; set; }

    public byte[] Image { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual Photographer Pfotographer { get; set; } = null!;

    public virtual ICollection<Portfolio> Portfolios { get; } = new List<Portfolio>();

    public virtual ICollection<ProfilServiceType> ProfilServiceTypes { get; } = new List<ProfilServiceType>();

    public virtual ICollection<Profiltypeshooting> Profiltypeshootings { get; } = new List<Profiltypeshooting>();
}
