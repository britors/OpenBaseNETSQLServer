using Microsoft.AspNetCore.Mvc;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Presentation.Api.Controllers.Customers;

[ApiController]
[Route("api/customer")]
public class CustomerGetByIdAsyncController(ICustomerApplicationService customerApplicationService)
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
}
