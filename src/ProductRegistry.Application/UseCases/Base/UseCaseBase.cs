using MediatR;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Domain.Core.Notications;

namespace ProductRegistry.Application.UseCases.Base
{
    public abstract class UseCaseBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : CommandRequest<TResponse>, new()
    {
        protected IHandler<DomainNotification> Notifications { get; }
        private readonly IMediator _mediator;

        protected UseCaseBase(IHandler<DomainNotification> notifications, IMediator mediator)
        {
            Notifications = notifications;
            _mediator = mediator;
        }

        public abstract Task<TResponse> HandleSafeMode(TRequest request, CancellationToken cancellationToken);

        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var result = await HandleSafeMode(request, cancellationToken);

            if (Notifications.HasError())
                await _mediator.Send(new ApiErrorLogRequest
                {
                    RootCause = $"[ApplicationError]",
                    Message = Notifications.GetErrorMessages(),
                    Type = "Error",
                    ExceptionStackTrace = string.Empty
                }, cancellationToken);

            return result;
        }
    }
}
