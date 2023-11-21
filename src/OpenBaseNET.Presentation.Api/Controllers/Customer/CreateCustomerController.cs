using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customer;

[Route("api/customer")]
[ApiController]
public class CreateCustomerController(ICustomerApplicationService customerApplicationService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken = default)
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
}