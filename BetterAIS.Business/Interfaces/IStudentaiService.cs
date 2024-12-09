using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IStudentaiService
{
    Task<IEnumerable<StudentaiDTO>> GetAllAsync();

    Task<StudentaiDTO> GetByIdAsync(string vidko);

    Task AddAsync(StudentaiDTO studentaiModel);

    Task UpdateAsync(StudentaiDTO studentaiModel);

    Task DeleteAsync(string vidko);
}