using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Interfaces.Extension;

namespace OpenBaseNET.Application.Interfaces.Services;

public interface ICustomerApplicationService : IApplicationService
{
    Task<IEnumerable<CustomerResponse>> FindByNameUsingDapperAsync(FindCustomerByNameRequest request);

    Task<IEnumerable<CustomerResponse>> FindByNameAsync(FindCustomerByNameRequest request);

    Task<UpdateCustomerResponse?> UpdateAsync(UpdateCustomerRequest request);

    Task<CreateCustomerResponse?> CreateAsync(CreateCustomerRequest request);

    Task<DeleteCustomerResponse?> DeleteAsync(DeleteCustomerRequest request);

    Task<CustomerResponse> GetByIdAsync(FindCustomerByIdRequest request);

    Task<PaginatedResponse<CustomerResponse>> GetAsync(GetCustomerRequest request);
}