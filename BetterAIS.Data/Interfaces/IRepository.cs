namespace BetterAIS.Data.Interfaces;

public interface IRepository<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(int id);
    Task AddAsync(TModel entity);
    Task UpdateAsync(TModel entity);
    Task DeleteAsync(int id);
}