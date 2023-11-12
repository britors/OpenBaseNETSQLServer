using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomer;

internal sealed class DeleteCustomerCommandHandler :
    IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse?>
{
    private readonly ICustomerDomainService _customerDomainService;

    public DeleteCustomerCommandHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task<DeleteCustomerResponse?>
        Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var success = await _customerDomainService.RemoveByIdAsync(request.Id);
        return new DeleteCustomerResponse(success);
    }
}