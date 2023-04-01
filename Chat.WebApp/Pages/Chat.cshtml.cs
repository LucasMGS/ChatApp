using Chat.Application.Commands.SendChatMessage;
using Chat.Application.Queries.GetChatMessage;
using Chat.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages;

public class ChatModel : PageModel
{
    private readonly IMediator _mediator;
    public ChatModel(IMediator mediator)
    {
        _mediator = mediator;
    }


    [BindProperty]
    public Guid ChatRoomId { get; set; }

    [BindProperty]
    public ChatMessageViewModel ChatMessage { get; set; }
    [BindProperty]
    public string ChatName { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        ChatRoomId = id;
        return Page();
    }
}
