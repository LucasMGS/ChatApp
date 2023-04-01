using Chat.Application.Commands.SendChatMessage;
using Chat.Application.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Chat.WebApp.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly IMediator _mediator;
        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task JoinChat(Guid chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task SendMessage(SendChatMessageCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return;
            
            var message = result.Value;

            await Clients.Group(command.ChatRoomId.ToString())
                .ReceiveMessage(message);
        }
    }
}
