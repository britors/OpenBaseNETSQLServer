using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface ICustomerDomainService : IDomainService<Customer, int>
{
    Task<IEnumerable<CustomerQueryResult>?>
        FindByNameAsync(string name);

    Task<PaginatedQueryResult<Customer>>
        FindByNamePagedAsync(int page, int pageSize);
}