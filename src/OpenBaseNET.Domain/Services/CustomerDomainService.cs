using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Services;

public sealed class CustomerDomainService
    (ICustomerRepository customerRepository) : DomainService<Customer, int>(customerRepository), ICustomerDomainService
{
    public async Task<IEnumerable<CustomerQueryResult>?>
        FindByNameAsync(string name)
    {
        return await customerRepository.FindByNameAsync(name);
    }

    public async Task<PaginatedQueryResult<Customer>>
        FindByNamePagedAsync(int page, int pageSize)
    {
        var total = await customerRepository.CountAsync();
        var result =
            await customerRepository.FindAsync(
                pageNumber: page,
                pageSize: pageSize);

        return new PaginatedQueryResult<Customer>(page, pageSize, total, result);
    }
}