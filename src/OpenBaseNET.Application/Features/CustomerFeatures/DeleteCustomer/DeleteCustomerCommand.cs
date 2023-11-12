using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomer;

public sealed class DeleteCustomerCommand : IRequest<DeleteCustomerResponse?>
{
    public int Id { get; set; }
}