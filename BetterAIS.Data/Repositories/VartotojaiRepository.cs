using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;
using NotFoundException = BetterAIS.Data.Validity.NotFoundException;

namespace BetterAIS.Data.Repositories;

public class VartotojaiRepository : IVartotojaiRepository
{
    private readonly BetterAisContext _context;

    public VartotojaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Vartotojai>> GetAllAsync()
    {
        return await _context.Vartotojai
            .Include(x => x.Destytojai)
            .Include(x => x.Studentai)
            .Include(x => x.Role)
            .ToListAsync();
    }

    public async Task<Vartotojai> GetByIdAsync(string vidko)
    {
        return await _context.Vartotojai
            .Include(x => x.Destytojai)
            .Include(x => x.Studentai)
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Vidko == vidko) ?? throw new NotFoundException($"Vartotojas nerastas");
    }

    public async Task AddAsync(Vartotojai entity)
    {
        await _context.Vartotojai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vartotojai entity)
    {
        var existing = await GetByIdAsync(entity.Vidko);

        entity.Slaptazodis = existing.Slaptazodis;

        _context.Vartotojai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string vidko)
    {
        var entity = await GetByIdAsync(vidko);
        _context.Vartotojai.Remove(entity);
        await _context.SaveChangesAsync();
    }
}