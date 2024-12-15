using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Uzduotys
{
    public int IdUzduotis { get; set; }

    public string Pavadinimas { get; set; } = null!;

    public string? Aprasymas { get; set; }

    public DateTime Terminas { get; set; } // Updated from DateOnly to DateTime

    public string? GriztamasisRysys { get; set; }

    public int Tipas { get; set; }

    public virtual ICollection<Suvestine> Suvestines { get; set; } = new List<Suvestine>();

    public virtual UzsiemimoTipai TipasNavigation { get; set; } = null!;
}
