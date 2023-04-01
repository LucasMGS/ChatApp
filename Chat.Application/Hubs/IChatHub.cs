using Chat.Application.Commands.SendChatMessage;
using Chat.Application.Shared;

namespace Chat.Application.Hubs;

public interface IChatHub
{
    Task ReceiveMessage(ChatMessageInfoViewModel command);
}
