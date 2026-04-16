using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers;

[ApiController]
[Route("api/customer")]
[Produces("application/json")]
public class CustomerController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
    /// <summary>Cria um cliente.</summary>
    /// <response code="201">Cliente criado com sucesso.</response>
    /// <response code="422">Dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await customerApplicationService.CreateAsync(request, cancellationToken);

        // POST → 201 Created com Location header apontando para o recurso criado
        return CreatedAtAction(nameof(GetByIdAsync), new { id = result!.Id }, result);
    }

    /// <summary>Remove um cliente.</summary>
    /// <response code="204">Cliente removido com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteCustomerRequest(id);
        var result = await customerApplicationService.DeleteAsync(request, cancellationToken);

        if (result is null)
            return NotFound();

        // DELETE bem-sucedido → 204 No Content (sem body)
        return NoContent();
    }

    /// <summary>Atualiza um cliente existente.</summary>
    /// <response code="200">Cliente atualizado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    /// <response code="422">Dados inválidos.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] int id,
        [FromBody] UpdateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        // Garante que o id da rota e do body são consistentes
        var requestWithId = request with { Id = id };
        var result = await customerApplicationService.UpdateAsync(requestWithId, cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>Lista clientes com paginação e filtro opcional por nome.</summary>
    /// <response code="200">Lista paginada de clientes.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await customerApplicationService.GetAsync(request, cancellationToken);
        return Ok(result);
    }

    /// <summary>Busca um cliente pelo id.</summary>
    /// <response code="200">Cliente encontrado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var result = await customerApplicationService.GetByIdAsync(
            new FindCustomerByIdRequest(id),
            cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>Lista clientes usando Dapper (alta performance).</summary>
    /// <response code="200">Lista paginada de clientes.</response>
    [HttpGet("dapper")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDapperAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await customerApplicationService.GetDapperAsync(request, cancellationToken);
        return Ok(result);
    }
}