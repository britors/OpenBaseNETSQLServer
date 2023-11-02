using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteApplicationService _clienteApplicationService;

    public ClienteController(IClienteApplicationService clienteApplicationService)
    {
        _clienteApplicationService = clienteApplicationService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BuscaClienteRequest request)
    {
        var result = await _clienteApplicationService.GetByNameAsync(request);
        return Ok(result);
    }
}