using Chat.Application.Abstractions;
using Chat.Core;
using Chat.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Queries.GetChatRoom
{
    public class GetChatRoomHandler : IQueryHandler<GetChatRoomQuery, List<GetChatRoomViewModel>>
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        public GetChatRoomHandler(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }
        public async Task<Result<List<GetChatRoomViewModel>>> Handle(GetChatRoomQuery request, CancellationToken cancellationToken)
        {
            var chatRooms = await _chatRoomRepository
                                        .Get()
                                        .OrderBy(x => x!.CreatedAt)
                                        .Select(x => new GetChatRoomViewModel(x!.Id, x.Name, x.Owner!.Name, x.CreatedAt,x.MaxUsers,x.Users.Count()))
                                        .ToListAsync();

            return Result.Success(chatRooms);
        }
    }
}
