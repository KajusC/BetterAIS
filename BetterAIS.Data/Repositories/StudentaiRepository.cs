using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class StudentaiRepository : IStudentaiRepository
{
    private readonly BetterAisContext _context;

    public StudentaiRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Studentai>> GetAllAsync()
    {
        return await _context.Studentai
            .Include(x => x.FinansavimasNavigation)
            .Include(x => x.StatusasNavigation)
            .Include(x => x.FkProgramosKodasNavigation)
            .Include(x => x.VidkoNavigation)
            .Include(x => x.Suvestines)
            .ToListAsync();
    }

    public async Task<Studentai> GetByIdAsync(string id)
    {
        var entity = await _context.Studentai
            .Include(x => x.FinansavimasNavigation)
            .Include(x => x.StatusasNavigation)
            .Include(x => x.FkProgramosKodasNavigation)
            .Include(x => x.VidkoNavigation)
            .Include(x => x.Suvestines)
            .FirstOrDefaultAsync(x => x.Vidko == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }
        return entity;
    }

    public async Task AddAsync(Studentai entity)
    {
        await _context.Studentai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Studentai entity)
    {
        _context.Studentai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _context.Studentai.FirstOrDefaultAsync(x => x.Vidko == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Studentai.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<string> GetLatestVidkoAsync()
    {
        var latestVidko = await _context.Studentai
            .OrderByDescending(x => x.Vidko)
            .Select(x => x.Vidko)
            .FirstOrDefaultAsync();

        return latestVidko;
    }
}