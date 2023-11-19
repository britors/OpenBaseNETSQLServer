using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;

internal sealed class CreateCustomerCommandHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse?>
{
    public async Task<CreateCustomerResponse?>
        Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(request);
        var newCustomer = await customerDomainService.AddAsync(customer, cancellationToken);
        return mapper.Map<CreateCustomerResponse>(newCustomer);
    }
}