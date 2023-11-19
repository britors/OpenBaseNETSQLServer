using Dapper;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.QueryResults;
using OpenBaseNET.Infra.Uow;

namespace OpenBaseNET.Infra.Data.Repositories;

public sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository, IDataRepository
{
    public CustomerRepository(DbSession dbSession,
        OneBaseDataBaseContext context,
        ILogger<CustomerRepository> logger) :
        base(dbSession, context, logger)
    {
    }

    public async Task<IEnumerable<CustomerQueryResult>?> FindByNameAsync(CancellationToken cancellationToken,
        string name)
    {
        var parms = new DynamicParameters();
        parms.Add("@Name", name + "%");

        const string query = """
                             SELECT
                                 CLIID AS ID,
                                 CLINM AS NAME
                             FROM CLITAB
                             WHERE
                                 CLINM LIKE @Name
                             """;

        return await QueryAsync<CustomerQueryResult>(query, cancellationToken, parms);
    }
}