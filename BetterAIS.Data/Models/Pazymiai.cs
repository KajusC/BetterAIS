using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Pazymiai
{
    public int IdPazymys { get; set; }

    public double Ivertinimas { get; set; }

    public DateOnly Data { get; set; }

    public int? FkIdSuvestine { get; set; }

    public virtual Suvestine? FkIdSuvestineNavigation { get; set; }
}
