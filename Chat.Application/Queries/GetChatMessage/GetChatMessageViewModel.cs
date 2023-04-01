using Chat.Application.Shared;

namespace Chat.Application.Queries.GetChatMessage;

public class ChatMessageViewModel
{
    public required Guid ChatRoomId { get; init; }
    public required string Name { get; init; }
    public IEnumerable<ChatMessageInfoViewModel> MessagesInfo { get; set; } = new List<ChatMessageInfoViewModel>();
}
