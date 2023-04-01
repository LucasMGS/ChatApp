using Chat.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.WebApp.Pages;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(SignInManager<IdentityUser<Guid>> signInManager, ILogger<LoginModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    [BindProperty]
    public LoginUserModel LoginUserModel { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var result = await _signInManager
                .PasswordSignInAsync(LoginUserModel.UserName, LoginUserModel.Password, LoginUserModel.RememberMe, false);
        if (result.Succeeded)
        {
            returnUrl ??= Url.Content("/HomeChatRoom");
            _logger.LogInformation("User {0} logged in", LoginUserModel.UserName);

            return LocalRedirect(returnUrl);
        }
        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        return Page();
    }
}
