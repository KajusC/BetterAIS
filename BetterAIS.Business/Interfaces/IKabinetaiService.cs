using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces
{
    public interface IKabinetaiService
    {
        Task<IEnumerable<KabinetaiDTO>> GetAllAsync();

        Task<KabinetaiDTO> GetByIdAsync(int id);

        Task AddAsync(KabinetaiDTO kabinetas);

        Task UpdateAsync(KabinetaiDTO kabinetas);

        Task DeleteAsync(int id);
    }
}
