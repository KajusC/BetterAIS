using BetterAIS.Data.Models;

public interface IPazymiaiRepository
{
    Task<IEnumerable<Pazymiai>> GetAllAsync();
    Task<Pazymiai> GetByIdAsync(int id);
    Task AddAsync(Pazymiai pazymys);
    Task UpdateAsync(Pazymiai pazymys);
    Task DeleteAsync(int id);
    Task<IEnumerable<Pazymiai>> GetGradesByStudentId(string studentId); // Method to fetch grades by student ID
}
