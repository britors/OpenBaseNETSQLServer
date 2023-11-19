using System.Linq.Expressions;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Services;

public sealed class CustomerDomainService
    (ICustomerRepository customerRepository) :
        DomainService<Customer, int>(customerRepository), ICustomerDomainService
{
    public async Task<PaginatedQueryResult<Customer>>
        FindByNamePagedAsync(string name, int page, int pageSize, CancellationToken cancellationToken)
    {
        Expression<Func<Customer, bool>>? query = null;
        if (!string.IsNullOrWhiteSpace(name))
            query = c => c.Name.Contains(name);    
        
        var totalRecords = await customerRepository.CountAsync(cancellationToken, query);
        
        var resultPaginated =
            await customerRepository.FindAsync(
                cancellationToken,
                query,
                pageNumber: page,
                pageSize: pageSize);

        return new PaginatedQueryResult<Customer>(page, pageSize, totalRecords, resultPaginated);
    }
}