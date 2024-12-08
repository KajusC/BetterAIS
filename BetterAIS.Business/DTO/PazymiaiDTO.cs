namespace BetterAIS.Business.DTO;

public class PazymiaiDTO
{
    public int IdPazymys { get; set; }
    public float Ivertinimas { get; set; }
    public DateTime Data { get; set; }
    public int? FkIdSuvestine { get; set; }
}
