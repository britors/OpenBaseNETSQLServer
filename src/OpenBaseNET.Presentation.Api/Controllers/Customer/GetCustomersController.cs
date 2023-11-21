using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customer;

[Route("api/customers")]
[ApiController]
public class GetCustomersController(ICustomerApplicationService customerApplicationService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default)
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
}