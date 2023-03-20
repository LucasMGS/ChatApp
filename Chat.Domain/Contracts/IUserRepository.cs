using Chat.Domain.Entities;

namespace Chat.Domain.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}
