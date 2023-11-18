using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;

internal sealed class DeleteCustomerCommandHandler(ICustomerDomainService customerDomainService)
    : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse?>
{
    public async Task<DeleteCustomerResponse?>
        Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var success = await customerDomainService.RemoveByIdAsync(request.Id, cancellationToken);
        return new DeleteCustomerResponse(success);
    }
}