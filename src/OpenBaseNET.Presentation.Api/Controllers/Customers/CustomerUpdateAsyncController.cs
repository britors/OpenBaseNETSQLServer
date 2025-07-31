using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customers;

[ApiController]
[Route("api/customer")]
public class CustomerUpdateAsyncController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
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
