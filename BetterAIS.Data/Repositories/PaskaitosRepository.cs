using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class PaskaitosRepository : IPaskaitosRepository
{
    public async Task<IEnumerable<Paskaitos>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Paskaitos> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Paskaitos entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Paskaitos entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}