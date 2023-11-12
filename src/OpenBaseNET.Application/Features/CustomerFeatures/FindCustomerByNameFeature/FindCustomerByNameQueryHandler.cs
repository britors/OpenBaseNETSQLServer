using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;

internal sealed class FindCustomerByNameQueryHandler :
    IRequestHandler<FindCustomerByNameQuery, IEnumerable<CustomerResponse>>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public FindCustomerByNameQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerResponse>>
        Handle(FindCustomerByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerDomainService
            .FindAsync(customer => customer.Name.Contains(request.Name));
        var customerResponses = _mapper.Map<IEnumerable<CustomerResponse>>(result);
        return customerResponses;
    }
}