using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Interfaces.Base;

namespace OpenBaseNET.Application.Interfaces.Services;

public interface ICustomerApplicationService : IApplicationService
{
    Task<UpdateCustomerResponse?> UpdateAsync(
        UpdateCustomerRequest request,
        CancellationToken cancellationToken);

    Task<CreateCustomerResponse?> CreateAsync(
        CreateCustomerRequest request,
        CancellationToken cancellationToken);

    Task<DeleteCustomerResponse?> DeleteAsync(
        DeleteCustomerRequest request,
        CancellationToken cancellationToken);

    Task<CustomerResponse> GetByIdAsync(
        FindCustomerByIdRequest request,
        CancellationToken cancellationToken);

    Task<PaginatedResponse<CustomerResponse>> GetAsync(
        GetCustomerRequest request,
        CancellationToken cancellationToken);
    
    Task<PaginatedResponse<CustomerResponse>> GetDapperAsync(
        GetCustomerRequest request,
        CancellationToken cancellationToken);
}