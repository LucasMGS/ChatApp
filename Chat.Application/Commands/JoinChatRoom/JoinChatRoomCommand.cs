using Chat.Application.Abstractions;

namespace Chat.Application.Commands.JoinChatRoom
{
    public record JoinChatRoomCommand(Guid chatRoomId) : ICommand;
}
