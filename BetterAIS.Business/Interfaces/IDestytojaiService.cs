using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces
{
    public interface IDestytojaiService
    {
        Task<IEnumerable<DestytojaiDTO>> GetAllAsync();

        Task<DestytojaiDTO> GetByIdAsync(string vidko);

        Task AddAsync(DestytojaiDTO destytojaiModel);

        Task UpdateAsync(DestytojaiDTO destytojaiModel);

        Task DeleteAsync(string vidko);

        Task<List<DestytojaiDTO>> GetSuggestedTeachersForModule(string moduleId);
    }
}
