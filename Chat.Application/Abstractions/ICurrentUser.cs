namespace Chat.Application.Abstractions;

public interface ICurrentUser
{
    Guid? Id { get; }
}
