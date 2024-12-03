using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class MoksliniaiLaipsniai
{
    public int IdMoksliniaiLaipsniai { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudijuPrograma> StudijuProgramas { get; set; } = new List<StudijuPrograma>();
}
