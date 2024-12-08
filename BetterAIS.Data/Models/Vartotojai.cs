using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Vartotojai
{
    public string Vidko { get; set; } = null!;

    public string Vardas { get; set; } = null!;

    public string Pavarde { get; set; } = null!;

    public DateOnly GimimoData { get; set; }

    public string TelefonoNr { get; set; } = null!;

    public string ElPastas { get; set; } = null!;

    public int RoleId { get; set; }

    public string Slaptazodis { get; set; } = null!;

    public virtual Destytojai? Destytojai { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Studentai? Studentai { get; set; }
}
