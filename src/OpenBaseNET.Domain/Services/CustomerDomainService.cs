using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Services;

public sealed class CustomerDomainService : DomainService<Customer, int>, ICustomerDomainService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(ICustomerRepository customerRepository) : base(customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerQueryResult>?>
        FindByNameAsync(string Name)
    {
        return await _customerRepository.FindByNameAsync(Name);
    }

    public async Task<PaginationQueryResult<Customer>>
        FindByNamePagedAsync(int page, int pageSize)
    {
        var total = await _customerRepository.CountAsync();
        var result =
            await _customerRepository.FindAsync(
                pagination: true,
                pageNumber: page,
                pageSize: pageSize);

        return new PaginationQueryResult<Customer>(page, pageSize, total, result);
    }
}