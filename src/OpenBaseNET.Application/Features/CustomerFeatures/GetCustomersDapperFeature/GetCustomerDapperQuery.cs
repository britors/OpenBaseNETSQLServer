using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersDapperFeature;

public sealed record GetCustomerDapperQuery(string Name, int Page, int PageSize) 
    : IRequest<PaginatedResponse<CustomerResponse>>;