using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class StudijuPrograma
{
    public string ProgramosKodas { get; set; } = null!;

    public string Pavadinimas { get; set; } = null!;

    public string Trukme { get; set; } = null!;

    public int KredituKiekis { get; set; }

    public int FakultetoId { get; set; }

    public string ProgramosAprasymas { get; set; } = null!;

    public int MokslinisLaipsnis { get; set; }

    public virtual MoksliniaiLaipsniai MokslinisLaipsnisNavigation { get; set; } = null!;

    public virtual ICollection<Studentai> Studentais { get; set; } = new List<Studentai>();
}
