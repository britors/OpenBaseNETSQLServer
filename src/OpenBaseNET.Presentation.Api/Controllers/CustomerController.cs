/*
 * Name: CustomerController
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Controller Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Controller para expor metodos para manipulação de clientes
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação da Classe                           |
 * |--------------------------------------------------------------|
 */

using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result
            = await customerApplicationService.CreateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result
            = await customerApplicationService.DeleteAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result
            = await customerApplicationService.UpdateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result
            = await customerApplicationService.GetAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.GetByIdAsync(
            new FindCustomerByIdRequest(id),
            cancellationToken
        );
        return Ok(result);
    }

    [HttpGet("dapper")]
    public async Task<IActionResult> GetDapperAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result
            = await customerApplicationService.GetDapperAsync(request, cancellationToken);
        return Ok(result);
    }
}
