using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomer;

public sealed class CreateCustomerCommand : IRequest<CreateCustomerResponse?>
{
    public string Name { get; set; } = string.Empty;
}