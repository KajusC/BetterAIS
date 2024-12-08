using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class PazymiaiRepository : IPazymiaiRepository
{
    public async Task<IEnumerable<Pazymiai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Pazymiai> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Pazymiai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Pazymiai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}