namespace Chat.Application.Commands.GetChatRoom;

public class GetChatRoomViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public GetChatRoomViewModel(Guid id, string name, string ownerName, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        OwnerName = ownerName;
        CreatedAt = createdAt;
    }
}
