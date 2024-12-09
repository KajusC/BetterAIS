using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Studentai
{
    public string Vidko { get; set; } = null!;

    public DateOnly StudijuPradzia { get; set; }

    public int Statusas { get; set; }

    public int Finansavimas { get; set; }

    public string FkProgramosKodas { get; set; }

    public virtual FinansavimoTipai FinansavimasNavigation { get; set; } = null!;

    public virtual StudijuPrograma FkProgramosKodasNavigation { get; set; } = null!;

    public virtual StudentoStatusai StatusasNavigation { get; set; } = null!;

    public virtual ICollection<Suvestine> Suvestines { get; set; } = new List<Suvestine>();

    public virtual Vartotojai VidkoNavigation { get; set; } = null!;
}
