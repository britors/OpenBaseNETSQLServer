using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customers;

[ApiController]
[Route("api/customer")]
public class CustomerDeleteAsyncController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.DeleteAsync(request, cancellationToken);
        return Ok(result);
    }
}
