using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class MoksliniaiLaipsniaiRepository : IMoksliniaiLaipsniaiRepository
{
    private readonly BetterAisContext _context;
    public MoksliniaiLaipsniaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MoksliniaiLaipsniai>> GetAllAsync()
    {
        return await _context.MoksliniaiLaipsniai.ToListAsync();
    }

    public async Task<MoksliniaiLaipsniai> GetByIdAsync(int id)
    {
        var entity = await _context.MoksliniaiLaipsniai.FirstOrDefaultAsync(x => x.IdMoksliniaiLaipsniai == id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;
    }

    public async Task AddAsync(MoksliniaiLaipsniai entity)
    {
        await _context.MoksliniaiLaipsniai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MoksliniaiLaipsniai entity)
    {
        _context.MoksliniaiLaipsniai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _context.MoksliniaiLaipsniai.Remove(entity);
        await _context.SaveChangesAsync();
    }
}