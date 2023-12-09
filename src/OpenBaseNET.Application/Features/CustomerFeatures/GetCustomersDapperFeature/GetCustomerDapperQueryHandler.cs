using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersDapperFeature;

public class GetCustomerDapperQueryHandler(
    ICustomerDomainService customerDomainService,
    IMapper mapper)
    : IRequestHandler<GetCustomerDapperQuery, PaginatedResponse<CustomerResponse>>
{
    public async Task<PaginatedResponse<CustomerResponse>> 
        Handle(GetCustomerDapperQuery request, CancellationToken cancellationToken)
    {
        var queryResult =
            await customerDomainService.FindByNameDapperPagedAsync(
                request.Name,
                request.Page,
                request.PageSize,
                cancellationToken);
        return mapper.Map<PaginatedResponse<CustomerResponse>>(queryResult);
    }
}