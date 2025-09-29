using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Base.Request;
using IAuthorizationService = OpenBaseNET.Application.Interfaces.Services.IAuthorizationService;

namespace OpenBaseNET.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthorizationService service) : ControllerBase
{
    [HttpPost("createtoken")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request, CancellationToken cancellationToken)
    {
        var token = await service.Authenticate(request, cancellationToken);
        return Ok(new { token });
    }
}
