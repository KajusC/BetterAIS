using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Destytojai
{
    public string Vidko { get; set; } = null!;

    public string Kvalifikacija { get; set; } = null!;

    public virtual ICollection<Moduliai> Moduliai { get; set; } = new List<Moduliai>();

    public virtual ICollection<Paskaitos> Paskaitos { get; set; } = new List<Paskaitos>();

    public virtual Vartotojai VidkoNavigation { get; set; } = null!;
}
