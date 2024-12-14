using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IVartotojaiService : ICrud<VartotojaiDTO, string>
{
    Task AddStudentVartotojas(VartotojaiDTO vartotojaiModel, StudentaiDTO studentaiModel);
    Task AddDestytojaiVartotojas(VartotojaiDTO vartotojaiModel, DestytojaiDTO destytojaiModel);

    Task UpdateStudentas(StudentaiDTO studentaiModel, VartotojaiDTO vartotojaiModel);

    Task DeleteStudentas(string modelId);
}