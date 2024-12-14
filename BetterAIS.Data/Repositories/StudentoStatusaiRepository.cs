using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class StudentoStatusaiRepository : IStudentoStatusaiRepository
{
    private readonly BetterAisContext _context;

    public StudentoStatusaiRepository(BetterAisContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<StudentoStatusai>> GetAllAsync()
    {
        return _context.StudentoStatusai.ToList();
    }

    public async Task<StudentoStatusai> GetByIdAsync(int id)
    {
        return await _context.StudentoStatusai.FindAsync(id);
    }

    public async Task AddAsync(StudentoStatusai entity)
    {
        await _context.StudentoStatusai.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StudentoStatusai entity)
    {
        _context.StudentoStatusai.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.StudentoStatusai.FindAsync(id);
        if (entity != null)
        {
            _context.StudentoStatusai.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}