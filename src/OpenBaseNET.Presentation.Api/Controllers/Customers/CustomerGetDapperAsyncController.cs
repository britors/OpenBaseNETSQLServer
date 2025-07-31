using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customers;

[ApiController]
[Route("api/customer")]
public class CustomerGetDapperAsyncController(
    ICustomerApplicationService customerApplicationService
) : ControllerBase
{
    [HttpGet("dapper")]
    public async Task<IActionResult> GetDapperAsync(
        [FromQuery] GetCustomerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await customerApplicationService.GetDapperAsync(request, cancellationToken);
        return Ok(result);
    }
}
