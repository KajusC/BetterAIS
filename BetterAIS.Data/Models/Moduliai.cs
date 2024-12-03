using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Moduliai
{
    public string Kodas { get; set; } = null!;

    public string Pavadinimas { get; set; } = null!;

    public string Destytojas { get; set; } = null!;

    public string UzsiemimuKiekis { get; set; } = null!;

    public string Kalba { get; set; } = null!;

    public string FkDestytojasVidko { get; set; } = null!;

    public virtual Destytojai FkDestytojasVidkoNavigation { get; set; } = null!;

    public virtual ICollection<Paskaitos> Paskaitos { get; set; } = new List<Paskaitos>();
}
