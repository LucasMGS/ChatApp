namespace Chat.Domain.Entities;

public class GroupChatMessage : EntityBase
{
    public string Message { get; private set; } = string.Empty;
    public Guid UserSenderId { get; private set; }
    public virtual User? UserSender { get; private set; } 

    public Guid ChatRoomId { get; private set; }
    public virtual ChatRoom? ChatRoom { get; private set; }

    public GroupChatMessage(string message, Guid userSenderId, Guid chatRoomId)
    {
        Message = ConvertMessageToHtml(message);
        UserSenderId = userSenderId;
        ChatRoomId = chatRoomId;
    }

    public string ConvertMessageToHtml(string message)
    {
        return message.Replace("\n", "<br>");
    }
}
