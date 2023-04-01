namespace Chat.Application.Abstractions;

public interface ISqsMessage : ICommand { }

public interface ISqsMessage<TResponse> : ICommand<TResponse> { }
