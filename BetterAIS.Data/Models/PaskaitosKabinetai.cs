using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class PaskaitosKabinetai
{
    public int FkIdPaskaita { get; set; }

    public int FkIdKabinetas { get; set; }

    public virtual Paskaitos FkIdPaskaitaNavigation { get; set; } = null!;
}
