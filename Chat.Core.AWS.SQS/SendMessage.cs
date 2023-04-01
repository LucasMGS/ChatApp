using System.Text.Json.Serialization;

namespace Chat.Core.SQS.Publisher;

public class SendMessage
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("chatRoomId")]
    public Guid ChatRoomId { get; set; }
}
