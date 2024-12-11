using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IUzduotysService
{
    Task<IEnumerable<UzduotysDTO>> GetAllAsync();
    Task<UzduotysDTO> GetByIdAsync(int id);
    Task AddAsync(UzduotysDTO uzduotis);
    Task UpdateAsync(UzduotysDTO uzduotis);
    Task DeleteAsync(int id);
}
