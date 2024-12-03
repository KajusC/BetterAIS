using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Fakultetai
{
    public int IdFakultetas { get; set; }

    public string Pavadinimas { get; set; } = null!;

    public string FakultetoKodas { get; set; } = null!;

    public string Dekanas { get; set; } = null!;

    public string Adresas { get; set; } = null!;

    public string Telefonas { get; set; } = null!;

    public virtual ICollection<Paskaitos> Paskaitos { get; set; } = new List<Paskaitos>();
}
