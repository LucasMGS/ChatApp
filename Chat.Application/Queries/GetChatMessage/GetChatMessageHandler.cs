using Chat.Application.Abstractions;
using Chat.Application.Shared;
using Chat.Core;
using Chat.Domain.Contracts;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Chat.Application.Queries.GetChatMessage;

public class GetChatMessageHandler : IQueryHandler<GetChatMessageQuery, ChatMessageViewModel>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    public GetChatMessageHandler(IChatRoomRepository chatRoomRepository)
    {
        _chatRoomRepository = chatRoomRepository;
    }

    public async Task<Result<ChatMessageViewModel>> Handle(GetChatMessageQuery request, CancellationToken cancellationToken)
    {
        var chatMessage = await _chatRoomRepository
            .GetAsNoTracking()
            .Where(x => x.Id == request.ChatRoomId)
            .Select(x => new ChatMessageViewModel
            {
                ChatRoomId = x.Id,
                Name = x.Name,
                MessagesInfo = x.Messages.OrderBy(x => x.CreatedAt)
                .Take(50)
                .Select(x => new ChatMessageInfoViewModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    SentAt = x.CreatedAt,
                    UserName = x.UserSender!.Name
                })
            }).FirstOrDefaultAsync(cancellationToken);

        return chatMessage;
    }
}
