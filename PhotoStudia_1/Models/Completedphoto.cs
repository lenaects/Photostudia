using System;
using System.Collections.Generic;

namespace PhotoStudia_1.Models;

public partial class Completedphoto
{
    public int Completedphotoid { get; set; }

    public int Orderid { get; set; }

    public string Filepath { get; set; } = null!;

    public DateOnly Completiondate { get; set; }

    public decimal Finalprice { get; set; }

    public virtual Order Order { get; set; } = null!;
}
