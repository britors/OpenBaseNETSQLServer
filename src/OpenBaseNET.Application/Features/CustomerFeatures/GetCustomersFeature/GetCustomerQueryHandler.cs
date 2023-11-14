using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersFeature;

internal sealed class GetCustomerQueryHandler(ICustomerDomainService customerDomainService,
        IMapper mapper)
    :
        IRequestHandler<GetCustomerQuery, PaginateResponse<CustomerResponse>>
{
    public async Task<PaginateResponse<CustomerResponse>>
        Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var queryResult =
            await customerDomainService.FindByNamePagedAsync(
                request.Page,
                request.PageSize);
        return mapper.Map<PaginateResponse<CustomerResponse>>(queryResult);
    }
}