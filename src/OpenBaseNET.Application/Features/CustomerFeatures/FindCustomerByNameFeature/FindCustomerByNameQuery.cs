using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;

public sealed class FindCustomerByNameQuery : IRequest<IEnumerable<CustomerResponse>>
{
    public string Name { get; set; } = string.Empty;
}