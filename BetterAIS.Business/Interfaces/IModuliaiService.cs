using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IModuliaiService
{
    Task<IEnumerable<ModuliaiDTO>> GetAllAsync();

    Task<ModuliaiDTO> GetByIdAsync(string kodas);

    Task AddAsync(ModuliaiDTO studentaiModel);

    Task UpdateAsync(ModuliaiDTO studentaiModel);

    Task DeleteAsync(string kodas);
}