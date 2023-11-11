using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers;

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
    public async Task<IActionResult> GetClienteDapper([FromQuery] BuscaClientePorNomeRequest request)
    {
        try
        {
            var result
                = await _clienteApplicationService.BuscarClientesPorNomeComDapperAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("buscar-nome")]
    public async Task<IActionResult> GetCliente([FromQuery] BuscaClientePorNomeRequest request)
    {
        try
        {
            var result
                = await _clienteApplicationService.BuscarClientesPorNomeAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] AtualizarClienteRequest request)
    {
        try
        {
            var result = await _clienteApplicationService.AtualizarAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request)
    {
        try
        {
            var result = await _clienteApplicationService.CadastrarAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletarClienteRequest request)
    {
        try
        {
            var result = await _clienteApplicationService.DeletarAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("buscar-id")]
    public async Task<IActionResult> Get([FromQuery] BuscaClienteRequest request)
    {
        try
        {
            var result = await _clienteApplicationService.BuscarClienteAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] TodosOsClientesRequest request)
    {
        try
        {
            var result
                = await _clienteApplicationService.TodosOsClientesAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}