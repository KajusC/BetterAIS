using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class SuvestineRepository : ISuvestineRepository
{
    private readonly BetterAisContext _context;

    public SuvestineRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Suvestine>> GetAllAsync()
    {
        return await _context.Suvestine
         .Include(x => x.FkIdPaskaitaNavigation)
         .Include(x => x.FkIdUzduotisNavigation)
         .Include(x => x.FkStudentasVidkoNavigation)
         .Include(x => x.Pazymiais)
         .ToListAsync();
    }

    public async Task<Suvestine> GetByIdAsync(int id)
    {

        var entity = await _context.Suvestine
            .Include(x=>x.FkIdPaskaitaNavigation)
            .Include(x=>x.FkIdUzduotisNavigation)
            .Include(x=>x.FkStudentasVidkoNavigation)
            .Include(x=>x.Pazymiais)
            .FirstOrDefaultAsync(x => x.IdSuvestine == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }
        return entity;
    }

    public async Task AddAsync(Suvestine entity)
    {
        await _context.Suvestine.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Suvestine entity)
    {
        _context.Suvestine.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Suvestine.FirstOrDefaultAsync(x => x.IdSuvestine == id);

        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Suvestine.Remove(entity);
        await _context.SaveChangesAsync();
    }
}