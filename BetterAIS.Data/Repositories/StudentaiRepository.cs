using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class StudentaiRepository : IStudentaiRepository
{
    public async Task<IEnumerable<Studentai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Studentai> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Studentai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Studentai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}