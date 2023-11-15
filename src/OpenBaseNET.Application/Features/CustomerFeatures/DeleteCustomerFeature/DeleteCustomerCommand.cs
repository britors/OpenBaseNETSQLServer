using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;

public sealed record DeleteCustomerCommand(int Id) : IRequest<DeleteCustomerResponse?>;