using Chat.Application.Abstractions;

namespace Chat.Application.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email, string Password) : ICommand
{

}
