using Chat.Domain.Entities;


namespace Chat.Domain.Contracts;

public interface IChatRoomRepository : IBaseRepository<ChatRoom>
{
    Task<ChatRoom?> GetChatRoomToSendMessage(Guid chatRoomId, Guid userId, CancellationToken cancellationToken);
    Task<ChatRoom?> GetWithUsersAsTracking(Guid chatRoomId);
}
