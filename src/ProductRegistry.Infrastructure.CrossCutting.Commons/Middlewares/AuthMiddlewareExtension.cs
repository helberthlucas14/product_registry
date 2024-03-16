using Microsoft.AspNetCore.Http;
using ProductRegistry.Domain.Events;
using ProductRegistry.Domain.Interfaces.Services;


namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Middlewares
{
    public class OwnerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IOwnerService _service;

        public OwnerMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, IOwnerService service)
        {

            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _service = service;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Headers.ContainsKey("ownerId"))
            {
                var ownerIdString = context.Request.Headers["ownerId"];

                if (Guid.TryParse(ownerIdString, out Guid ownerId))
                {
                    _httpContextAccessor.HttpContext.Session.SetString("OwnerId", ownerId.ToString());

                    if (ownerId != _service.OwnerId)
                        await _service.SetOwnerId(ownerId);

                    await _next(context);
                    return;
                }
            }
            else
            {
                await _service.SetOwnerId(Guid.Empty);
                await _next(context);
                return;
            }

            await _next(context);
        }
    }
}
