using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class FakultetaiRepository : IFakultetaiRepository
{
    public async Task<IEnumerable<Fakultetai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Fakultetai> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Fakultetai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Fakultetai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}