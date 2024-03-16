using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;
using ProductRegistry.Domain.Interfaces.Services;


namespace ProductRegistry.Domain.Services
{
    public class SnsService : ISnsService
    {
        private readonly IAmazonSimpleNotificationService _snsClient;

        public SnsService(string serviceUrl, string awsAccessKeyId, string awsSecretAccessKey)
        {
            var awsCredentials = new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);

            var config = new AmazonSimpleNotificationServiceConfig
            {
                ServiceURL = serviceUrl
            };
            _snsClient = new AmazonSimpleNotificationServiceClient(awsCredentials, config);
        }

        public async Task PublishMessageAsync(string topicArn, string message)
        {
            var request = new PublishRequest
            {
                TopicArn = topicArn,
                Message = message
            };
            await _snsClient.PublishAsync(request);
        }
    }
}
