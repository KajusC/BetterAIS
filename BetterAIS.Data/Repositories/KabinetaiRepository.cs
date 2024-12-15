using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class KabinetaiRepository : IKabinetaiRepository
{
    private readonly BetterAisContext _context;

    public KabinetaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Kabinetai>> GetAllAsync()
    {
        return await _context.Kabinetai.ToListAsync();
    }

    public async Task<Kabinetai> GetByIdAsync(int id)
    {
        var entity = await _context.Kabinetai.FirstOrDefaultAsync(x => x.IdKabinetas == id);

        if (entity == null)
        {
            throw new Exception("Kabinetas nerastas");
        }
        return entity;
    }

    public async Task AddAsync(Kabinetai entity)
    {
        await _context.Kabinetai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Kabinetai entity)
    {
        var existingEntity = await _context.Kabinetai.FindAsync(entity.IdKabinetas);
        if (existingEntity == null)
        {
            throw new ArgumentException("Kabineto nėra");
        }
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Kabinetai.FirstOrDefaultAsync(x => x.IdKabinetas == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Kabinetai.Remove(entity);
        await _context.SaveChangesAsync();
    }
}