using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Photographer
{
    public int Photographerid { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Photographerschedule> Photographerschedules { get; } = new List<Photographerschedule>();

    public virtual ICollection<Profilphotographer> Profilphotographers { get; } = new List<Profilphotographer>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
