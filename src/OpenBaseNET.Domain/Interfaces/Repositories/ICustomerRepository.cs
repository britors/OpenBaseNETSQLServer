using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<IEnumerable<CustomerQueryResult>?> FindByNameAsync(CancellationToken cancellationToken, string name);
}