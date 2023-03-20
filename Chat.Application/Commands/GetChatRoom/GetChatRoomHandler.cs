using Chat.Application.Abstractions;
using Chat.Core;
using Chat.Domain.Contracts;

namespace Chat.Application.Commands.GetChatRoom
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
    

            return Result.Success(new List<GetChatRoomViewModel>());
        }
    }
}
