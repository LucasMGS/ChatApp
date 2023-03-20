using Chat.Application.Abstractions;

namespace Chat.Application.Commands.CreateChatRoom
{
    public record CreateChatRoomCommand(string Name, int maxUsers, Guid ownerId) : ICommand
    {
    }
}