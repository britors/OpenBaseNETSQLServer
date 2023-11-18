using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;

internal sealed class FindCustomerByIdQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    : IRequestHandler<FindCustomerByIdQuery, CustomerResponse>
{
    public async Task<CustomerResponse>
        Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await customerDomainService
            .GetByIdAsync(request.Id, cancellationToken);

        var customer = mapper.Map<CustomerResponse>(result);
        return customer;
    }
}