using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class PaskaitosTipai
{
    public int IdPaskaitosTipai { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Paskaitos> Paskaitos { get; set; } = new List<Paskaitos>();
}
