using Microsoft.AspNetCore.Mvc;

namespace ProductRegistry.Api.Controllers.Base
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/[controller]")]
    public class MainController : Controller
    {
    }
}
