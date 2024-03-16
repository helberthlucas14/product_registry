using AutoMapper;
using ProductRegistry.Application.Events.Base;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Providers;
using static ProductRegistry.Infrastructure.CrossCutting.Commons.Providers.AwsSettingsProvider;

namespace ProductRegistry.Application.Events.Products
{
    public class ProductEventHandler : EventHandlerBase<ProductEventRequest>
    {
        private readonly AwsSettingsProvider.SnsSettings _snsSettings;
        private readonly IMapper _mapper;
        private readonly ISnsService _snsService;
        public ProductEventHandler(IHandler<DomainNotification> notifications,
            IMapper mapper,
            ISnsService snsService,
            AwsSettingsProvider snsSettings) : base(notifications)
        {
            _mapper = mapper;
            _snsService = snsService;
            _snsSettings = snsSettings.SNS;
        }

        public override async Task Handle(ProductEventRequest notification, CancellationToken cancellationToken)
        {
            await _snsService.PublishMessageAsync(_snsSettings.TopicArn, notification.Message);
        }
    }
}
