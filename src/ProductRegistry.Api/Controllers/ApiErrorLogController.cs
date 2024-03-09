using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductRegistry.Api.Controllers.Base;
using ProductRegistry.Application.Commons.Responses;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Enums;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductRegistry.Api.Controllers
{
    public class ApiErrorLogController : MainController
    {
        private readonly IMediator _mediator;

        public ApiErrorLogController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Errors Report
        /// </summary>
        /// <returns></returns>
        [HttpGet("{format}"), AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(byte[]))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(InternalValidationProblemDetails))]
        public async Task<IActionResult> GetAsync(ReportFormat format, [FromQuery] DateTime startDate, DateTime endDate)
        {
            var result = await _mediator.Send(new GetErrorsRequest { Format = format, StartDate = startDate, EndDate = endDate });
            return File(result.File, result.Format.GetDescription(), "ErrorsReport");
        }
    }
}
