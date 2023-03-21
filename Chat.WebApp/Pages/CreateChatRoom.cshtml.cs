using Chat.Application.Abstractions;
using Chat.Application.Commands.CreateChatRoom;
using Chat.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages
{
    public class CreateChatRoomModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CreateChatRoomModel> _logger;
        private readonly ICurrentUser _baseController;

        public CreateChatRoomModel(ILogger<CreateChatRoomModel> logger,IMediator mediator,ICurrentUser baseController)
        {
            _logger = logger;
            _mediator = mediator;
            _baseController = baseController;
        }

        [BindProperty]
        public RegisterChatRoomModel RegisterChatRoomModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var createChatRoomCommand = new CreateChatRoomCommand(RegisterChatRoomModel.Name, RegisterChatRoomModel.MaxUsers, _baseController.Id!.Value);
            var result = await _mediator.Send(createChatRoomCommand);
            if (!result.IsSuccess)
            {
                return Page();
            }
            return LocalRedirect("~/Chat");
        }
    }
}
