using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace BetterAIS.Data.Repositories;

public class FakultetaiRepository : IFakultetaiRepository
{
    private readonly BetterAisContext _context;

    public FakultetaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Fakultetai>> GetAllAsync()
    {
        return await _context.Fakultetai.ToListAsync();
    }

    public async Task<Fakultetai> GetByIdAsync(int id)
    {
        var entity = await _context.Fakultetai.FirstOrDefaultAsync(x => x.IdFakultetas == id);

        if (entity == null)
        {
            throw new Exception("Fakultetas nerastas");
        }
        return entity;
    }

    public async Task AddAsync(Fakultetai entity)
    {
        await _context.Fakultetai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Fakultetai entity)
    {
        var existingEntity = await _context.Fakultetai.FindAsync(entity.IdFakultetas);
        if (existingEntity == null)
        {
            throw new ArgumentException("Fakulteto nėra");
        }
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Fakultetai.FirstOrDefaultAsync(x => x.IdFakultetas == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Fakultetai.Remove(entity);
        await _context.SaveChangesAsync();
    }
}