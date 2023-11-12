using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;

internal sealed class UpdateCustomerCommandHandler :
    IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse?>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerResponse?>
        Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        var updatedCustomer = await _customerDomainService.UpdateAsync(customer);
        return _mapper.Map<UpdateCustomerResponse>(updatedCustomer);
    }
}