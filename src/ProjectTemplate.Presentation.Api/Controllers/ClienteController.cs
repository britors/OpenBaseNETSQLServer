using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Interfaces.Services;

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

    [HttpGet("buscar-nome-dapper")]
    public async Task<IActionResult> Get([FromQuery] BuscaClienteRequest request)
    {
        var result = await _clienteApplicationService.BuscarClientesPorNomeComDapperAsync(request);
        return Ok(result);
    }
}