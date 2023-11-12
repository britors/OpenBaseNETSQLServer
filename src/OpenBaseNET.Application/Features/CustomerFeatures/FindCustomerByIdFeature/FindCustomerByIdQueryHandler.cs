using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;

internal sealed class FindCustomerByIdQueryHandler :
    IRequestHandler<FindCustomerByIdQuery, CustomerResponse>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public FindCustomerByIdQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<CustomerResponse>
        Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerDomainService
            .GetByIdAsync(request.Id);

        var customer = _mapper.Map<CustomerResponse>(result);
        return customer;
    }
}