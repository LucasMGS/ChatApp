namespace Chat.Application.Shared
{
    public class ChatMessageInfoViewModel
    {
        public required Guid Id { get; init; }
        public required string Message { get; init; }
        public required DateTimeOffset SentAt { get; init; }
        public required string? UserName { get; init; }

        public string SentAtString => SentAt
            .LocalDateTime
            .ToString("dd/MM/yyyy HH:mm");
    }
}