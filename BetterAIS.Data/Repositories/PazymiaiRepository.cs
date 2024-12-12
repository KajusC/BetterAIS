using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class PazymiaiRepository : IPazymiaiRepository
{
    private readonly BetterAisContext _context;

    public PazymiaiRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pazymiai>> GetAllAsync()
    {
        return await _context.Pazymiai
            .Include(p => p.FkIdSuvestineNavigation) // Include related data as needed.
            .ToListAsync();
    }

    public async Task<Pazymiai> GetByIdAsync(int id)
    {
        return await _context.Pazymiai
            .Include(p => p.FkIdSuvestineNavigation)
            .FirstOrDefaultAsync(p => p.IdPazymys == id);
    }

    public async Task AddAsync(Pazymiai entity)
    {
        await _context.Pazymiai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pazymiai entity)
    {
        _context.Pazymiai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException();
        _context.Pazymiai.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
