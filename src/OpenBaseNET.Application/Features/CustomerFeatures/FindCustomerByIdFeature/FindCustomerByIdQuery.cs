using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;

public sealed class FindCustomerByIdQuery : IRequest<CustomerResponse>
{
    public int Id { get; set; }
}