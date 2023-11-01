using Microsoft.AspNetCore.Mvc;

namespace ProjectTemplate.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}