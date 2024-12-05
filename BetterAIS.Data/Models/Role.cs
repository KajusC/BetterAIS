using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vartotojai> Vartotojais { get; set; } = new List<Vartotojai>();
}
