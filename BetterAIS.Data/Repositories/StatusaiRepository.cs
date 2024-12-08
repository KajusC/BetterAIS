using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class StatusaiRepository : IStatusaiRepository
{
    public async Task<IEnumerable<Statusai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Statusai> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Statusai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Statusai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}