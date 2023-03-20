using Chat.Core;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Chat.Domain.Entities;

public class ChatRoom : EntityBase
{
    public string Name { get; init; }
    public int MaxUsers { get; private set; }
    public Guid OwnerId { get; set; }
    public virtual User? Owner { get; set; }

    private readonly List<ChatRoomUser> _users = new();
    public virtual IReadOnlyList<ChatRoomUser> Users => _users.AsReadOnly();

    private readonly List<GroupChatMessage> _messages = new();
    public virtual IReadOnlyList<GroupChatMessage> Messages => _messages.AsReadOnly();

    public ChatRoom(string name, int maxUsers, Guid ownerId)
    {
        Name = name;
        MaxUsers = maxUsers;
        OwnerId = ownerId;

        AddUser(ownerId);
    }

    public Result AddUser(Guid userId)
    {
        var existUser = _users.Any(u => u.UserId == userId);
        if (existUser)
        {
            return Result.Success();
        }

        if(_users.Count == MaxUsers)
        {
            return Result.WithError(new Error("Chat with max capacity"));
        }

        _users.Add(new ChatRoomUser(Id,userId));
        return Result.Success();
    }

    public void AddMessage(GroupChatMessage messageObj)
    {
        _messages.Add(messageObj);
    }
}
