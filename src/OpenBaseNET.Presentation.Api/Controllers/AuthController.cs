using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Base.Request;
using IAuthorizationService = OpenBaseNET.Application.Interfaces.Services.IAuthorizationService;

namespace OpenBaseNET.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthorizationService service) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous] // Permite acesso a este endpoint sem token
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var token = await service.Authenticate(request, cancellationToken);
            return Ok(new { token = token });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "Erro interno ao autenticar." });
        }
    }
}
