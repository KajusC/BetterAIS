using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace BetterAIS.Data.Repositories;

public class ModuliaiRepository : IModuliaiRepository
{
    private readonly BetterAisContext _context;

    public ModuliaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Moduliai>> GetAllAsync()
    {
        return await _context.Moduliai.ToListAsync();
    }

    public async Task<Moduliai> GetByIdAsync(string id)
    {
        var entity = await _context.Moduliai.FirstOrDefaultAsync(x => x.Kodas == id);

        if (entity == null)
        {
            throw new Exception("Modulis nerastas.");
        }
        return entity;
    }

    public async Task AddAsync(Moduliai entity)
    {
        await _context.Moduliai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Moduliai entity)
    {
        var existingEntity = await _context.Moduliai.FindAsync(entity.Kodas);
        if (existingEntity == null)
        {
            throw new ArgumentException("Modulis nerastas.");
        }
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _context.Moduliai.FirstOrDefaultAsync(x => x.Kodas == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Moduliai.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Moduliai>> GetModulesByTeacherIdAsync(string vidko)
    {
        return await _context.Moduliai
                .Where(m => m.FkDestytojasVidko == vidko)
                .Include(m => m.Paskaitos)
                .ToListAsync();
    }
}