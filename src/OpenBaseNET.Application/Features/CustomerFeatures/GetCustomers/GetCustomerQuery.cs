using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomers;

public sealed class GetCustomerQuery : IRequest<PaginateResponse<CustomerResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}