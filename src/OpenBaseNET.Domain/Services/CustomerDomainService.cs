using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Services;

public sealed class CustomerDomainService
    (ICustomerRepository customerRepository) :
        DomainService<Customer, int>(customerRepository), ICustomerDomainService
{
    public async Task<IEnumerable<CustomerQueryResult>?>
        FindByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await customerRepository.FindByNameAsync(cancellationToken, name);
    }

    public async Task<PaginatedQueryResult<Customer>>
        FindByNamePagedAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var total = await customerRepository.CountAsync(cancellationToken);
        var result =
            await customerRepository.FindAsync(
                cancellationToken,
                pageNumber: page,
                pageSize: pageSize);

        return new PaginatedQueryResult<Customer>(page, pageSize, total, result);
    }
}