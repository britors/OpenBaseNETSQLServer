using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;

public sealed record FindCustomerByNameQuery(string Name) : IRequest<IEnumerable<CustomerResponse>>;