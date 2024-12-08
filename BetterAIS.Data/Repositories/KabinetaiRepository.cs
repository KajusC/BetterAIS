using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class KabinetaiRepository : IKabinetaiRepository
{
    public async Task<IEnumerable<Kabinetai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Kabinetai> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Kabinetai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Kabinetai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}