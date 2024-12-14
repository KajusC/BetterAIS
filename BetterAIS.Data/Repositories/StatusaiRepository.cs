using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class StatusaiRepository : IStatusaiRepository
{
    private readonly BetterAisContext _context;

    public StatusaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Statusai>> GetAllAsync()
    {
        return _context.Statusai.ToList();
    }

    public async Task<Statusai> GetByIdAsync(int id)
    {
        return await _context.Statusai.FindAsync(id);
    }

    public async Task AddAsync(Statusai entity)
    {
        await _context.Statusai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Statusai entity)
    {
        _context.Statusai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Statusai.FindAsync(id);
        if (entity != null)
        {
            _context.Statusai.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}