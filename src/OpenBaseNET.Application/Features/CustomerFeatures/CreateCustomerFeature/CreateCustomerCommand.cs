using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;

public sealed record CreateCustomerCommand(string Name) : IRequest<CreateCustomerResponse?>;