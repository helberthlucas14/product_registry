namespace ProductRegistry.Domain.Interfaces.Services
{
    public interface ISnsService
    {
        Task PublishMessageAsync(string topicArn, string message);
    }
}
