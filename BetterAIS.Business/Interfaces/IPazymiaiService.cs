using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IPazymiaiService
{
    Task<IEnumerable<PazymiaiDTO>> GetAllAsync();
    Task<PazymiaiDTO> GetByIdAsync(int id);
    Task AddAsync(PazymiaiDTO pazymys);
    Task UpdateAsync(PazymiaiDTO pazymys);
    Task DeleteAsync(int id);
}
