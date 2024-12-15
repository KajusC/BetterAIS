using BetterAIS.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetterAIS.Business.Interfaces
{
    public interface IPazymiaiService
    {
        Task<IEnumerable<PazymiaiDTO>> GetAllAsync();
        Task<PazymiaiDTO> GetByIdAsync(int id);
        Task AddAsync(PazymiaiDTO pazymys);
        Task UpdateAsync(PazymiaiDTO pazymys);
        Task DeleteAsync(int id);
        Task<IEnumerable<PazymiaiDTO>> GetGradesByStudentIdAsync(string studentId); // New Method
    }
}
