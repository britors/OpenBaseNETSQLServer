using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersFeature;

internal sealed class GetCustomerQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    : IRequestHandler<GetCustomerQuery, PaginatedResponse<CustomerResponse>>
{
    public async Task<PaginatedResponse<CustomerResponse>>
        Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {

        var queryResult =
            await customerDomainService.FindByNamePagedAsync(
                request.Name,
                request.Page,
                request.PageSize,
                cancellationToken);
        return mapper.Map<PaginatedResponse<CustomerResponse>>(queryResult);
    }
}