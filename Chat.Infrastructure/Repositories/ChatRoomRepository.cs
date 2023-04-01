using Chat.Domain.Contracts;
using Chat.Domain.Entities;
using Chat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories;

public class ChatRoomRepository : BaseRepository<ChatRoom>, IChatRoomRepository
{
    public ChatRoomRepository(ChatContext chatContext) : base(chatContext)
    {
    }

    public async Task<ChatRoom?> GetChatRoomToSendMessage(Guid chatRoomId, Guid userId, CancellationToken cancellationToken)
    {
        return await Get()
            .Where(x => x.Id == chatRoomId)
            .Include(x => x.Users.Where(u => u.UserId == userId))
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<ChatRoom?> GetWithUsersAsTracking(Guid chatRoomId)
    {
        return Get()
            .Include(x => x.Users)
            .FirstOrDefaultAsync(c => c.Id == chatRoomId);
    }
}
