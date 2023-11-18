using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerApplicationService customerApplicationService) : ControllerBase
{
    [HttpGet("find")]
    public async Task<IActionResult> GetAsync([FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.GetAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("find-by-name-dapper")]
    public async Task<IActionResult> FindByNameUsingDapperAsync([FromQuery] FindCustomerByNameRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.FindByNameUsingDapperAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("find-name")]
    public async Task<IActionResult> FindByNameAsync([FromQuery] FindCustomerByNameRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.FindByNameAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync([FromQuery] FindCustomerByIdRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await customerApplicationService.GetByIdAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.UpdateAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.CreateAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCustomerRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result
                = await customerApplicationService.DeleteAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }        
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}