using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;

public sealed class UpdateCustomerCommand : IRequest<UpdateCustomerResponse?>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}