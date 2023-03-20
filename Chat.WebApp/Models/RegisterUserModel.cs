using Chat.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Chat.WebApp.Models;

public class RegisterUserModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    [Display(Name="Confirm password")]
    public string ConfirmPassword { get; set; }

}
