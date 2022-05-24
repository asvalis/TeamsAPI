namespace TeamsAPI.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}