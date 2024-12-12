using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class UzduotysRepository : IUzduotysRepository
{
    private readonly BetterAisContext _context;

    public UzduotysRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Uzduotys>> GetAllAsync()
    {
        return await _context.Uzduotys
            .Include(u => u.TipasNavigation) // Include related data if necessary
            .ToListAsync();
    }

    public async Task<Uzduotys> GetByIdAsync(int id)
    {
        return await _context.Uzduotys
            .Include(u => u.TipasNavigation)
            .FirstOrDefaultAsync(u => u.IdUzduotis == id);
    }

    public async Task AddAsync(Uzduotys entity)
    {
        await _context.Uzduotys.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Uzduotys entity)
    {
        var existingEntity = await _context.Uzduotys.FindAsync(entity.IdUzduotis);
        if (existingEntity == null)
        {
            throw new ArgumentException("Task not found.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Uzduotys.FindAsync(id);
        if (entity == null)
        {
            throw new ArgumentException("Task not found.");
        }

        _context.Uzduotys.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
