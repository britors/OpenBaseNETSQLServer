using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<IEnumerable<CustomerQueryResult>> FindByNameAsync(
        string name,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);
    Task<CountQueryResult> CustomerCoutAsync(string name, CancellationToken cancellationToken);
}