using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Kabinetai
{
    public int IdKabinetas { get; set; }

    public int Numeris { get; set; }

    public int Aukstas { get; set; }

    public string FakultetoKodas { get; set; } = null!;
}
