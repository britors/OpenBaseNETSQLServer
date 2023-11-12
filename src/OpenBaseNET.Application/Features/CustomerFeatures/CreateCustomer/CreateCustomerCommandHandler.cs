using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomer;

internal sealed class CreateCustomerCommandHandler :
    IRequestHandler<CreateCustomerCommand, CreateCustomerResponse?>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<CreateCustomerResponse?>
        Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        var newCusomer = await _customerDomainService.AddAsync(customer);
        return _mapper.Map<CreateCustomerResponse>(newCusomer);
    }
}