using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;

internal sealed class UpdateCustomerCommandHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse?>
{
    public async Task<UpdateCustomerResponse?>
        Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(request);
        var updatedCustomer = await customerDomainService.UpdateAsync(customer, cancellationToken);
        return mapper.Map<UpdateCustomerResponse>(updatedCustomer);
    }
}