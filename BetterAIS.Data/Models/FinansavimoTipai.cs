using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class FinansavimoTipai
{
    public int IdFinansavimoTipai { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Studentai> Studentais { get; set; } = new List<Studentai>();
}
