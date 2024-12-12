using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly BetterAisContext _context; 


    public RoleRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        return await _context.Roles.FirstOrDefaultAsync(x => x.IdRoles == id);
    }

    public async Task AddAsync(Role entity)
    {
        await _context.Roles.AddAsync(entity);
        await _context.SaveChangesAsync();
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