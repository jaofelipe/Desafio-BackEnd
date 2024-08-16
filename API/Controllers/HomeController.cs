using DesafioBackEnd.API.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
