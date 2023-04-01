namespace Chat.Domain.Contracts;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity?> FindAsync(Guid id);
    IQueryable<TEntity> GetAsNoTracking();
    IQueryable<TEntity?> Get();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
