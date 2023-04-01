using Chat.Application.Abstractions;
using Chat.Core;
using Chat.Domain.Contracts;

namespace Chat.Application.Commands.JoinChatRoom
{
    public class JoinChatRoomHandler : ICommandHandler<JoinChatRoomCommand>
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly ICurrentUser _currentUser;
        public JoinChatRoomHandler(IChatRoomRepository chatRoomRepository,ICurrentUser currentUser)
        {
            _chatRoomRepository = chatRoomRepository;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(JoinChatRoomCommand request, CancellationToken cancellationToken)
        {
            var chatRoom = await _chatRoomRepository.GetWithUsersAsTracking(request.chatRoomId);
            if(chatRoom is null)
            {
                return new Error("ChatRoom not found");
            }

            var userId = _currentUser.Id!.Value;

            if(chatRoom.ContainsUser(userId))
            {
                return Result.Success();
            }

            var result = chatRoom.AddUser(userId);

            if(!result.IsSuccess) 
            {
                return result;
            }

            await _chatRoomRepository.SaveChangesAsync(cancellationToken);

            return Result.Success();

        }
    }
}
