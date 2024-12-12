using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IFakultetaiService
{
    Task<IEnumerable<FakultetaiDTO>> GetAllAsync();

    Task<FakultetaiDTO> GetByIdAsync(int id);

    Task AddAsync(FakultetaiDTO fakultetas);

    Task UpdateAsync(FakultetaiDTO fakultetas);

    Task DeleteAsync(int id);
}