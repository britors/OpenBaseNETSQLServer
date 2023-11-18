using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;

internal sealed class FindCustomerByNameQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    : IRequestHandler<FindCustomerByNameQuery, IEnumerable<CustomerResponse>>
{
    public async Task<IEnumerable<CustomerResponse>>
        Handle(FindCustomerByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await customerDomainService
            .FindAsync(cancellationToken,
                customer => customer.Name.Contains(request.Name));
        var customerResponses = mapper.Map<IEnumerable<CustomerResponse>>(result);
        return customerResponses;
    }
}