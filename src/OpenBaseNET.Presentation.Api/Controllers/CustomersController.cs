﻿using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
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

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.GetAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("dapper")]
    public async Task<IActionResult> GetDapperAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.GetDapperAsync(
            request,
            cancellationToken
        );
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.CreateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.DeleteAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.UpdateAsync(request, cancellationToken);
        return Ok(result);
    }
}
