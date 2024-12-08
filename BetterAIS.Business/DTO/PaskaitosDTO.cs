namespace BetterAIS.Business.DTO;

public class PaskaitosDTO
{
    public int IdPaskaita { get; set; }
    public DateTime Data { get; set; }
    public int Trukme { get; set; }
    public bool Privalomas { get; set; }
    public int Tipas { get; set; }
    public string FkModulisKodas { get; set; }
    public int FkIdFakultetas { get; set; }
    public string FkDestytojasVidko { get; set; }
}
