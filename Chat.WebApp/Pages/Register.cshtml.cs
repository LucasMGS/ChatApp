using Chat.Application.Commands.CreateUser;
using Chat.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages;

public class RegisterModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly ILogger<RegisterModel> _logger;

    [BindProperty]
    public RegisterUserModel RegisterUserModel { get; set; }
    public string? ReturnUrl { get; set; }
    public RegisterModel(IMediator mediator, ILogger<RegisterModel> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public Task OnGetAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
        return Task.CompletedTask;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
        {
            return Page();
        }
        CreateUserCommand createUserCommand = new CreateUserCommand(RegisterUserModel.Name, RegisterUserModel.Email, RegisterUserModel.Password);
        var result = await _mediator.Send(createUserCommand, default);
        if (!result.IsSuccess)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return Page();
        }

        _logger.LogInformation("User created a new account with password");
        return LocalRedirect(returnUrl);

    }
}
