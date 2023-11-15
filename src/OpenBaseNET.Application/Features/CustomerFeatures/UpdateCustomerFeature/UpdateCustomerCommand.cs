using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;

public sealed record UpdateCustomerCommand(int Id, string Name) : IRequest<UpdateCustomerResponse?>;