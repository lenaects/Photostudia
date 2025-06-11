using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public string Nameclient { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Feedback1 { get; set; }

    public int Profilphotographerid { get; set; }

    public int Rating { get; set; }

    public virtual Profilphotographer Profilphotographer { get; set; } = null!;
}
