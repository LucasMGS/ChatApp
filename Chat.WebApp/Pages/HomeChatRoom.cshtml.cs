using Chat.Application.Commands.GetChatRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages
{
    public class HomeChatRoom: PageModel
    {
        private readonly IMediator _mediator;
        private ILogger<HomeChatRoom> _logger;
        public List<GetChatRoomViewModel> ChatRooms { get; set; }
        public HomeChatRoom(IMediator mediator, ILogger<HomeChatRoom> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult>OnGetAsync()
        {
            var result = await _mediator.Send(new GetChatRoomQuery());
            ChatRooms = result.Value;
            return Page();
        }
    }
}
