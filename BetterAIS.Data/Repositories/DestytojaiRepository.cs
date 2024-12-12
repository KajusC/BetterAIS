using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class DestytojaiRepository : IDestytojaiRepository
{
    private readonly BetterAisContext _context;

    public DestytojaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Destytojai>> GetAllAsync()
    {
        return await _context.Destytojai.ToListAsync();
    }

    public async Task<Destytojai> GetByIdAsync(string id)
    {
        var entity = await _context.Destytojai.FirstOrDefaultAsync(x => x.Vidko == id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;
    }

    public async Task AddAsync(Destytojai entity)
    {
        await _context.Destytojai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Destytojai entity)
    {
        var existingEntity = await _context.Destytojai.FindAsync(entity.Vidko);
        if (existingEntity == null)
        {
            throw new ArgumentException("destytojo nera");
        }
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _context.Destytojai.FirstOrDefaultAsync(x => x.Vidko == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Destytojai.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<string> GetLatestVidkoAsync()
    {
        var entity = await _context.Destytojai.OrderByDescending(x => x.Vidko).FirstOrDefaultAsync();
        return entity?.Vidko;
    }
}