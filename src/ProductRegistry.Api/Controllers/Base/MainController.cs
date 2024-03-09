using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistry.Application.Commons.Responses;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;

namespace ProductRegistry.Api.Controllers.Base
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/[controller]")]
    public class MainController : Controller
    {
        protected IHandler<DomainNotification> Notifications { get; }

        public MainController(IHandler<DomainNotification> notifications)
        {
            Notifications = notifications;
        }

        protected bool IsValidOperation() => !Notifications.HasNotifications();
        protected ActionResult ResponsePutPatch()
        {
            if (IsValidOperation())
                return NoContent();

            return ResponseBadRequest();
        }

        protected ActionResult ResponseDelete()
        {
            if (!IsValidOperation())
                return ResponseBadRequest();

            return NoContent();
        }

        protected ActionResult ResponseBadRequest()
        {
            return BadRequest(new InternalValidationProblemDetails(Notifications.GetNotificationsByKey()));
        }

        protected ActionResult<T> ResponsePost<T>(string action, object route, T result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NoContent();

                return CreatedAtAction(action, route, result);
            }

            return ResponseBadRequest();
        }

        protected ActionResult<T> ResponsePost<T>(string action, string controller, object route, T result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NoContent();

                return CreatedAtAction(action, controller, route, result);
            }

            return ResponseBadRequest();
        }

        protected ActionResult<IEnumerable<T>> ResponseGet<T>(IEnumerable<T> result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NoContent();

                return Ok(result);
            }

            return ResponseBadRequest();
        }

        protected ActionResult<T> ResponseGet<T>(T result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            return ResponseBadRequest();
        }

    }
}
