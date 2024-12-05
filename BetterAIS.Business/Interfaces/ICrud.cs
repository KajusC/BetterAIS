namespace BetterAIS.Business.Interfaces;

public interface ICrud<TModel, TId> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync();

    Task<TModel> GetByIdAsync(TId id);

    Task AddAsync(TModel model);

    Task UpdateAsync(TModel model);

    Task DeleteAsync(TId modelId);
}