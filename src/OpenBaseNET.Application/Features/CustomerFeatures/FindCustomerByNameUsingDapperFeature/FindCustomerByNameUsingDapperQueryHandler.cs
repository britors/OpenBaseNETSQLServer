using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;

internal sealed class FindCustomerByNameUsingDapperQueryHandler :
    IRequestHandler<FindCustomerByNameUsingDapperQuery, IEnumerable<CustomerResponse>>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public FindCustomerByNameUsingDapperQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerResponse>>
        Handle(FindCustomerByNameUsingDapperQuery request, CancellationToken cancellationToken)
    {
        var result
            = await _customerDomainService.FindByNameAsync(request.Name);
        var customerResponses = _mapper.Map<IEnumerable<CustomerResponse>>(result);
        return customerResponses;
    }
}