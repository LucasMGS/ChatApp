using Amazon.SQS;
using Amazon.SQS.Model;
using Chat.Application.Abstractions;
using Chat.Core.Messaging;
using MediatR;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Chat.Core.SQS.Consumer
{
    public class QueueConsumerService : BackgroundService
    {
        private AmazonSQSClient SQSClient { get; set; }
        private readonly IOptions<QueueSettings> _queueSettings;
        private string queueURL { get; set; } = string.Empty;
        private readonly IMediator _mediator;
        private readonly ILogger<QueueConsumerService> _logger;

        public QueueConsumerService(IMediator mediator,IOptions<QueueSettings> queueSettings, ILogger<QueueConsumerService> logger)
        {
            _mediator = mediator;
            SQSClient = new AmazonSQSClient();
            _queueSettings = queueSettings;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Consume(new CancellationToken());
        }

        private async Task Consume(CancellationToken cancellationToken)
        {
            await GetQueueURL();
            var receiveMessageRequest = new ReceiveMessageRequest()
            {
                QueueUrl = queueURL,
                AttributeNames = new List<string>() { "All" },
                MessageAttributeNames= new List<string>() { "All" },
                MaxNumberOfMessages = 1,                
            };

            var response = await SQSClient.ReceiveMessageAsync(receiveMessageRequest,cancellationToken);
            foreach (var messageReceived in response.Messages)
            {
                //var obj = JsonSerializer.Deserialize<NewMessage>(messageReceived.Body);
                
                var messageType = messageReceived.MessageAttributes["MessageType"].StringValue;
                var type = Type.GetType($"Chat.Application.Commands.SendChatMessage.{messageType}");
                if(type is null)
                {
                    _logger.LogWarning("Unknown message type: {MessageType}", messageType);
                    continue;
                }

                var typedMessage = (ISqsMessage)JsonSerializer.Deserialize(messageReceived.Body, type)!;

                try
                {
                    var x = await _mediator.Send(typedMessage, cancellationToken);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Message failed during processing");
                    continue;
                }

                await SQSClient.DeleteMessageAsync(queueURL, messageReceived.ReceiptHandle, cancellationToken);
            }
        }

        private async Task GetQueueURL()
        {
            if (!string.IsNullOrEmpty(queueURL))
                return;

            var queueResponse = await SQSClient.GetQueueUrlAsync(_queueSettings.Value.Name) ;
            queueURL = queueResponse.QueueUrl;
        }        
    }
}