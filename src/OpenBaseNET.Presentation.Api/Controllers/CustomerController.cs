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
    public async Task<IActionResult> GetAsync([FromQuery] GetCustomerRequest request)
    {
        try
        {
            var result
                = await customerApplicationService.GetAsync(request);
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

    [HttpGet("find-by-name-dapper")]
    public async Task<IActionResult> FindByNameUsingDapperAsync([FromQuery] FindCustomerByNameRequest request)
    {
        try
        {
            var result
                = await customerApplicationService.FindByNameUsingDapperAsync(request);
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

    [HttpGet("find-name")]
    public async Task<IActionResult> FindByNameAsync([FromQuery] FindCustomerByNameRequest request)
    {
        try
        {
            var result
                = await customerApplicationService.FindByNameAsync(request);
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
    public async Task<IActionResult> GetByIdAsync([FromQuery] FindCustomerByIdRequest request)
    {
        try
        {
            var result = await customerApplicationService.GetByIdAsync(request);
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
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerRequest request)
    {
        try
        {
            var result = await customerApplicationService.UpdateAsync(request);
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
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest request)
    {
        try
        {
            var result = await customerApplicationService.CreateAsync(request);
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
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCustomerRequest request)
    {
        try
        {
            var result = await customerApplicationService.DeleteAsync(request);
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