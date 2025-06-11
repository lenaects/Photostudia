using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int Clientid { get; set; }

    public int Serviceid { get; set; }

    public int Photographerid { get; set; }

    public DateOnly Orderdate { get; set; }

    public DateOnly Appointmentdate { get; set; }

    public TimeOnly Starttime { get; set; }

    public TimeOnly Endtime { get; set; }

    public int? Typeshootingid { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Completedphoto> Completedphotos { get; } = new List<Completedphoto>();

    public virtual ICollection<Mobileorder> Mobileorders { get; } = new List<Mobileorder>();

    public virtual Photographer Photographer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Typeshooting? Typeshooting { get; set; }
}
