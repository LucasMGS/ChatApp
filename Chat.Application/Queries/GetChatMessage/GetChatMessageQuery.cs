using Chat.Application.Abstractions;

namespace Chat.Application.Queries.GetChatMessage;

public record GetChatMessageQuery(Guid ChatRoomId) : IQuery<ChatMessageViewModel>
{

}
