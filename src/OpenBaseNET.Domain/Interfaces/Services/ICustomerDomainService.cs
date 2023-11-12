using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface ICustomerDomainService : IDomainService<Customer, int>
{
    Task<IEnumerable<CustomerQueryResult>?>
        FindByNameAsync(string Name);

    Task<PaginationQueryResult<Customer>>
        FindByNamePagedAsync(int page, int pageSize);
}