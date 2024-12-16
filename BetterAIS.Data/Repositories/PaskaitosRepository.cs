using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class PaskaitosRepository : IPaskaitosRepository
{
    private readonly BetterAisContext _context;

    public PaskaitosRepository(BetterAisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Paskaitos>> GetAllAsync()
    {
        return await _context.Paskaitos
            .Include(p => p.FkDestytojasVidkoNavigation)
            .Include(p => p.FkIdFakultetasNavigation)
            .Include(p => p.FkModulisKodasNavigation)
            .Include(p => p.TipasNavigation)
            .ToListAsync();
    }

    public async Task<Paskaitos> GetByIdAsync(int id)
    {
        return await _context.Paskaitos
            .Include(p => p.FkDestytojasVidkoNavigation)
            .Include(p => p.FkIdFakultetasNavigation)
            .Include(p => p.FkModulisKodasNavigation)
            .Include(p => p.TipasNavigation)
            .FirstOrDefaultAsync(p => p.IdPaskaita == id);
    }

    public async Task AddAsync(Paskaitos entity)
    {
        await _context.Paskaitos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paskaitos entity)
    {
        var existingEntity = await _context.Paskaitos.FindAsync(entity.IdPaskaita);
        if (existingEntity == null)
        {
            throw new ArgumentException("Lecture not found.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Paskaitos.FindAsync(id);
        if (entity == null)
        {
            throw new ArgumentException("Lecture not found.");
        }

        _context.Paskaitos.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Paskaitos>> GetUpcomingLecturesAsync(DateTime currentTime)
    {
        return await _context.Paskaitos
            .Where(p => p.Data >= currentTime.Date) // Fetch only upcoming lectures
            .Include(p => p.PaskaitosKabinetais)
            .Include(p => p.FkModulisKodas)
            .OrderBy(p => p.Data)
            .ThenBy(p => p.Trukmė)
            .ToListAsync();
    }
}
