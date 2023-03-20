using Chat.Application.Abstractions;
using Chat.Core;
using Chat.Domain.Contracts;
using Chat.Domain.Entities;


namespace Chat.Application.Commands.CreateChatRoom
{
    public class CreateChatRoomHandler : ICommandHandler<CreateChatRoomCommand>
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        public CreateChatRoomHandler(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public async Task<Result> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
        {
            var chatRoom = new ChatRoom(request.Name.Trim(), request.maxUsers,request.ownerId);
            _chatRoomRepository.Add(chatRoom);
            await _chatRoomRepository.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
