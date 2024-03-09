using ProductRegistry.Domain.Core.Messages;


namespace ProductRegistry.Application.Interfaces.Base
{
    public interface IUseCaseBase<TRequest, TResponse> : IDisposable
        where TRequest : CommandRequest<TResponse>, new()
    {
        Task<TResponse> RegisterAsync(TRequest request);
    }
}
