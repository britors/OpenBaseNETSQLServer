using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;

internal sealed class FindCustomerByNameUsingDapperQueryHandler(ICustomerDomainService customerDomainService,
        IMapper mapper)
    :
        IRequestHandler<FindCustomerByNameUsingDapperQuery, IEnumerable<CustomerResponse>>
{
    public async Task<IEnumerable<CustomerResponse>>
        Handle(FindCustomerByNameUsingDapperQuery request, CancellationToken cancellationToken)
    {
        var result
            = await customerDomainService.FindByNameAsync(request.Name);
        var customerResponses = mapper.Map<IEnumerable<CustomerResponse>>(result);
        return customerResponses;
    }
}