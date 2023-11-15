using MediatR;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;

public sealed record FindCustomerByNameUsingDapperQuery(string Name) : IRequest<IEnumerable<CustomerResponse>>;