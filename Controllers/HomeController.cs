using DesafioBackEnd.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Controllers
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
