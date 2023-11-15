using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Application.Services;

public sealed class CustomerApplicationService(IMediator mediator, IMapper mapper) : ICustomerApplicationService
{
    public async Task<UpdateCustomerResponse?>
        UpdateAsync(UpdateCustomerRequest request)
    {
        var query = mapper.Map<UpdateCustomerCommand>(request);
        return await mediator.Send(query);
    }

    public async Task<IEnumerable<CustomerResponse>>
        FindByNameAsync(FindCustomerByNameRequest request)
    {
        var query = mapper.Map<FindCustomerByNameQuery>(request);
        return await mediator.Send(query);
    }

    public async Task<IEnumerable<CustomerResponse>>
        FindByNameUsingDapperAsync(FindCustomerByNameRequest request)
    {
        var query = mapper.Map<FindCustomerByNameUsingDapperQuery>(request);
        return await mediator.Send(query);
    }

    public async Task<CreateCustomerResponse?>
        CreateAsync(CreateCustomerRequest request)
    {
        var query = mapper.Map<CreateCustomerCommand>(request);
        return await mediator.Send(query);
    }

    public async Task<DeleteCustomerResponse?> DeleteAsync(DeleteCustomerRequest request)
    {
        var query = mapper.Map<DeleteCustomerCommand>(request);
        return await mediator.Send(query);
    }

    public async Task<CustomerResponse> GetByIdAsync(FindCustomerByIdRequest request)
    {
        var query = mapper.Map<FindCustomerByIdQuery>(request);
        return await mediator.Send(query);
    }

    public async Task<PaginatedResponse<CustomerResponse>> GetAsync(GetCustomerRequest request)
    {
        var query = mapper.Map<GetCustomerQuery>(request);
        return await mediator.Send(query);
    }
}