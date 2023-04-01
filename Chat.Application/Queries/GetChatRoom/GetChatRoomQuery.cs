using Chat.Application.Abstractions;

namespace Chat.Application.Queries.GetChatRoom;

public record GetChatRoomQuery() : IQuery<List<GetChatRoomViewModel>>
{
}
