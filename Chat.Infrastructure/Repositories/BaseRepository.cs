using Chat.Domain;
using Chat.Domain.Contracts;
using Chat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Chat.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntityBase
    {
        private readonly ChatContext _chatContext;
        public BaseRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        public void Add(TEntity entity) => _chatContext.Add(entity);
        
        public void Delete(TEntity entity) => _chatContext.Remove(entity);

        public async Task<TEntity?> FindAsync(Guid id) => await Get().FirstOrDefaultAsync(entity => entity.Id == id);

        public IQueryable<TEntity> Get() => _chatContext.Set<TEntity>().AsTracking();

        public IQueryable<TEntity> GetAsNoTracking() => _chatContext.Set<TEntity>().AsNoTracking();

        public Task SaveChangesAsync(CancellationToken cancellationToken) => _chatContext.SaveChangesAsync(cancellationToken);

        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            _chatContext.Set<TEntity>().Update(entity);
        }
    }
}
