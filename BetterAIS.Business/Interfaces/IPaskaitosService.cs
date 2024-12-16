using BetterAIS.Business.DTO;

namespace BetterAIS.Business.Interfaces;

public interface IPaskaitosService
{
    Task<IEnumerable<PaskaitosDTO>> GetAllAsync();
    Task<PaskaitosDTO> GetByIdAsync(int id);
    Task AddAsync(PaskaitosDTO paskaita);
    Task UpdateAsync(PaskaitosDTO paskaita);
    Task DeleteAsync(int id);

    // New Method for Upcoming Lectures
    //Task<IEnumerable<PaskaitosDTO>> GetUpcomingLecturesAsync();
}
