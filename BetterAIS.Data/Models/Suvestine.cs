using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Suvestine
{
    public int IdSuvestine { get; set; }

    public bool Dalyvavo { get; set; }

    public string FkStudentasVidko { get; set; } = null!;

    public int FkIdUzduotis { get; set; }

    public int FkIdPaskaita { get; set; }

    public virtual Paskaitos FkIdPaskaitaNavigation { get; set; } = null!;

    public virtual Uzduotys FkIdUzduotisNavigation { get; set; } = null!;

    public virtual Studentai FkStudentasVidkoNavigation { get; set; } = null!;

    public virtual ICollection<Pazymiai> Pazymiais { get; set; } = new List<Pazymiai>();
}
