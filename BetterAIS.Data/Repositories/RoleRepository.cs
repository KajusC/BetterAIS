using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Role entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Role entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}