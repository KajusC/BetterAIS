using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class UzsiemimoTipai
{
    public int IdUzsiemimoTipai { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Uzduotys> Uzduoties { get; set; } = new List<Uzduotys>();
}
