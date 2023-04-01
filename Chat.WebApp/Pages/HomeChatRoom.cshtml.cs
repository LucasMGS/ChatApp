using Chat.Application.Commands.JoinChatRoom;
using Chat.Application.Queries.GetChatRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages
{
    public class HomeChatRoom: PageModel
    {
        private readonly IMediator _mediator;
        private ILogger<HomeChatRoom> _logger;

        [BindProperty]
        public List<GetChatRoomViewModel> ChatRooms { get; set; }
        public Guid ChatID { get; set; }

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

        public async Task<IActionResult> OnPostAsync(Guid chatId)
        {
            var result = await _mediator.Send(new JoinChatRoomCommand(chatId));
            if (result.IsSuccess)
            {
                return Redirect($"/Chat?Id={chatId}");
            }
            return BadRequest(new
            {
                errors = result.Errors.Select(e => e.Message),
            });
        }
    }
}
