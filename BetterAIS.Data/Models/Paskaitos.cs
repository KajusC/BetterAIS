using System;
using System.Collections.Generic;

namespace BetterAIS.Data.Models;

public partial class Paskaitos
{
    public int IdPaskaita { get; set; }

    public DateOnly Data { get; set; }

    public int Trukmė { get; set; }

    public bool Privalomas { get; set; }

    public int Tipas { get; set; }

    public string FkModulisKodas { get; set; } = null!;

    public int FkIdFakultetas { get; set; }

    public string FkDestytojasVidko { get; set; } = null!;

    public virtual Destytojai FkDestytojasVidkoNavigation { get; set; } = null!;

    public virtual Fakultetai FkIdFakultetasNavigation { get; set; } = null!;

    public virtual Moduliai FkModulisKodasNavigation { get; set; } = null!;

    public virtual ICollection<PaskaitosKabinetai> PaskaitosKabinetais { get; set; } = new List<PaskaitosKabinetai>();

    public virtual ICollection<Suvestine> Suvestines { get; set; } = new List<Suvestine>();

    public virtual PaskaitosTipai TipasNavigation { get; set; } = null!;
}
