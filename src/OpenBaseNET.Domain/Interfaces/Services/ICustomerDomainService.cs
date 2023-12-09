using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface ICustomerDomainService : IDomainService<Customer, int>
{
    Task<PaginatedQueryResult<Customer>>
        FindByNamePagedAsync(string name, int page, int pageSize, CancellationToken cancellationToken);
    
    Task<PaginatedQueryResult<CustomerQueryResult>>
        FindByNameDapperPagedAsync(string name, int page, int pageSize, CancellationToken cancellationToken);
}