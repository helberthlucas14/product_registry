using AutoMapper;
using MediatR;
using ProductRegistry.Application.Interfaces.Base;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services.Base;

namespace ProductRegistry.Application.UseCases.Base
{
    public abstract class UseCaseBaseRequestToDomain<TRequest, TDomainModel, TResponse> :
            UseCaseBase<TRequest, TResponse>, IUseCaseBase<TRequest, TResponse>
            where TRequest : CommandRequest<TResponse>, new()
            where TDomainModel : Entity, new()
    {
        protected IBaseServiceEntity<TDomainModel> BaseDomainService { get; }
        protected IMapper Mapper { get; }

        protected UseCaseBaseRequestToDomain(
            IHandler<DomainNotification> notifications,
            IMediator mediator,
            IBaseServiceEntity<TDomainModel> baseService,
            IMapper mapper) : base(notifications, mediator)
        {
            BaseDomainService = baseService;
            Mapper = mapper;
        }

        public async Task<TResponse> RegisterAsync(TRequest request)
        {
            var registerCommand = Mapper.Map<TDomainModel>(request);
            registerCommand = await BaseDomainService.RegisterAsync(registerCommand);
            var registerResponse = Mapper.Map<TResponse>(registerCommand);
            return registerResponse;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}
