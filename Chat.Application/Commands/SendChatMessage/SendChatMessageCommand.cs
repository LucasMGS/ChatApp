using Chat.Application.Abstractions;
using Chat.Application.Shared;

namespace Chat.Application.Commands.SendChatMessage;

public class SendChatMessageCommand : ISqsMessage<ChatMessageInfoViewModel>
{
    public Guid ChatRoomId { get; set; }
    public string Message { get; set; } = string.Empty;

    public SendChatMessageCommand(Guid chatRoomId, string message)
    {
        ChatRoomId = chatRoomId;
        Message = message;
    }
}
