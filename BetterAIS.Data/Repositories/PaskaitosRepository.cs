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
        return await _context.Paskaitos.ToListAsync();
    }

    public async Task<Paskaitos> GetByIdAsync(int id)
    {
        var entity = await _context.Paskaitos.FirstOrDefaultAsync(x => x.IdPaskaita == id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;
    }

    public async Task AddAsync(Paskaitos entity)
    {
        await _context.Paskaitos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paskaitos entity)
    {
        _context.Paskaitos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _context.Paskaitos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}