using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;

public sealed record FindCustomerByIdQuery(int Id) : IRequest<CustomerResponse>;