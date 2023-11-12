using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomers;

internal sealed class GetCustomerQueryHandler :
    IRequestHandler<GetCustomerQuery, PaginateResponse<CustomerResponse>>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(
        ICustomerDomainService customerDomainService,
        IMapper mapper)
    {
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<PaginateResponse<CustomerResponse>>
        Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var queryResult =
            await _customerDomainService.FindByNamePagedAsync(
                request.Page,
                request.PageSize);
        return _mapper.Map<PaginateResponse<CustomerResponse>>(queryResult);
    }
}