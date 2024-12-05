namespace BetterAIS.Data.Interfaces;

public interface IRepository<TModel, TId> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(TId id);
    Task AddAsync(TModel entity);
    Task UpdateAsync(TModel entity);
    Task DeleteAsync(TId id);
}