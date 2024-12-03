using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class UzduotysRepository : IUzduotysRepository
{
    public async Task<IEnumerable<Uzduotys>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Uzduotys> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Uzduotys entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Uzduotys entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}