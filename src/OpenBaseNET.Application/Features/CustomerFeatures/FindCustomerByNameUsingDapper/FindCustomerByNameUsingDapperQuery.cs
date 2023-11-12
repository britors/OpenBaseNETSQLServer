using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapper;

public sealed class FindCustomerByNameUsingDapperQuery : IRequest<IEnumerable<CustomerResponse>>
{
    public string Name { get; set; } = string.Empty;
}