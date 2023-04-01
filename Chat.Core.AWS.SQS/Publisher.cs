using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

namespace Chat.Core.SQS.Publisher
{
    public class Publisher
    {
        private AmazonSQSClient SQSClient { get; set; }
        private string queueURL { get; set; } = string.Empty;

        Publisher()
        {
            SQSClient = new AmazonSQSClient();
        }

        public async void Publish<TMessage>(TMessage message)
        {
            try
            {
                await getQueueURL();
                var sendMessageRequest = new SendMessageRequest()
                {
                    QueueUrl = queueURL,
                    MessageBody = JsonSerializer.Serialize(message),
                    MessageAttributes = new Dictionary<string, MessageAttributeValue>()
                    {
                        {
                            "MessageType", new MessageAttributeValue
                            {
                                DataType = "String",
                                StringValue = nameof(message)
                            }
                        }
                    }
                };

                var response = await SQSClient.SendMessageAsync(sendMessageRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task getQueueURL()
        {
            if(queueURL != string.Empty)
                return;
            
            var queueResponse = await SQSClient.GetQueueUrlAsync("chatMessages");
            queueURL = queueResponse.QueueUrl;
        }
    }
}