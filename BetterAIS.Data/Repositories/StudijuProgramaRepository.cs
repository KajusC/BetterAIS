using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Repositories;

public class StudijuProgramaRepository : IStudijuProgramaRepository
{
    private readonly BetterAisContext _context;
    public StudijuProgramaRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<StudijuPrograma>> GetAllAsync()
    {
        return await _context.StudijuPrograma
            .Include(x => x.MokslinisLaipsnisNavigation)
            .Include(x => x.Studentais)
            .ToListAsync();
    }

    public async Task<StudijuPrograma> GetByIdAsync(string id)
    {
        var entity = await _context.StudijuPrograma
            .Include(x => x.MokslinisLaipsnisNavigation)
            .Include(x => x.Studentais)
            .FirstOrDefaultAsync(x => x.ProgramosKodas == id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;

    }

    public async Task AddAsync(StudijuPrograma entity)
    {
        await _context.StudijuPrograma.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StudijuPrograma entity)
    {
        _context.StudijuPrograma.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        _context.StudijuPrograma.Remove(entity);
        await _context.SaveChangesAsync();
    }
}