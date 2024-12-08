using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class FinansavimoTipaiRepository : IFinansavimoTipaiRepository
{
    private readonly BetterAisContext _context;

    public FinansavimoTipaiRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FinansavimoTipai>> GetAllAsync()
    {
        return await _context.FinansavimoTipai.ToListAsync();
    }

    public async Task<FinansavimoTipai> GetByIdAsync(int id)
    {
        var entity = await _context.FinansavimoTipai.FirstOrDefaultAsync(x => x.IdFinansavimoTipai == id);

        if (entity == null) {

            throw new Exception("Entity not found");
        }
        return entity;
    }

    public async Task AddAsync(FinansavimoTipai entity)
    {
        await _context.FinansavimoTipai.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FinansavimoTipai entity)
    {
        _context.FinansavimoTipai.Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        _context.FinansavimoTipai.Remove(entity);

        await _context.SaveChangesAsync();
    }
}