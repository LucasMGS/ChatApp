namespace Chat.Application.Queries.GetChatRoom;

public class GetChatRoomViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int MaxUsers { get; set; }
    public int UsersAmount { get; set; }

    public GetChatRoomViewModel(Guid id, string name, string ownerName, DateTimeOffset createdAt, int maxUsers, int usersAmount)
    {
        Id = id;
        Name = name;
        OwnerName = ownerName;
        CreatedAt = createdAt;
        MaxUsers = maxUsers;
        UsersAmount = usersAmount;
    }
}
