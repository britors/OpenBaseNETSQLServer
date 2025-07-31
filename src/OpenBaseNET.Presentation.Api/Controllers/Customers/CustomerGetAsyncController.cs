using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customers;

[ApiController]
[Route("api/customer")]
public class CustomerGetAsyncController(ICustomerApplicationService customerApplicationService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.GetAsync(request, cancellationToken);
        return Ok(result);
    }
}
