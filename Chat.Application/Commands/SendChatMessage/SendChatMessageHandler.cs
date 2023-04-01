using Chat.Application.Abstractions;
using Chat.Application.Shared;
using Chat.Core;
using Chat.Domain.Contracts;
using Chat.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Chat.Application.Commands.SendChatMessage;

public class SendChatMessageHandler : ICommandHandler<SendChatMessageCommand, ChatMessageInfoViewModel>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly ICurrentUser _currentUser;
    private readonly ILogger<SendChatMessageHandler> _logger;
    public SendChatMessageHandler(IChatRoomRepository chatRoomRepository, ICurrentUser currentUser, ILogger<SendChatMessageHandler> logger)
    {
        _chatRoomRepository = chatRoomRepository;
        _currentUser = currentUser;
        _logger = logger;
    }

    public async Task<Result<ChatMessageInfoViewModel>> Handle(SendChatMessageCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _currentUser.Id!.Value;
        var chatRoom = await _chatRoomRepository.GetChatRoomToSendMessage(request.ChatRoomId, loggedUserId, cancellationToken);
        if (chatRoom is null)
        {
            _logger.LogWarning("Chat Room to send message not found");
            return new Error("Chat room not found");
        }

        if (!chatRoom.ContainsUser(loggedUserId))
        {
            return new Error("User not allowed to send message");
        }

        var message = new GroupChatMessage(request.Message, loggedUserId, request.ChatRoomId);
        chatRoom.AddMessage(message);

        await _chatRoomRepository.SaveChangesAsync(cancellationToken);
        var userName = chatRoom.Users.LastOrDefault(x => x.UserId == loggedUserId)?.User?.Name;
        return new ChatMessageInfoViewModel
        {
            Id = message.Id,
            Message = message.Message,
            SentAt = message.CreatedAt,
            UserName = userName ?? "Unknown user"
        };
    }

}

   
