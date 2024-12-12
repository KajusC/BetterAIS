namespace BetterAIS.Business.DTO;

public class StudentaiDTO : VartotojaiDTO
{
    public string Vidko { get; set; }
    public DateTime StudijuPradzia { get; set; }
    public int Statusas { get; set; }
    public int Finansavimas { get; set; }
    public string FkProgramosKodas { get; set; }
}
