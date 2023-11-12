using Dapper;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.QueryResults;
using OpenBaseNET.Infra.Mssql.Uow;

namespace OpenBaseNET.Infra.Data.Mssql.Repositories;

public sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository, IDataRepository
{
    public CustomerRepository(DbSession dbSession,
        ProjectDbContext context,
        ILogger<CustomerRepository> logger) :
        base(dbSession, context, logger)
    {
    }

    public async Task<IEnumerable<CustomerQueryResult>?> FindByNameAsync(string name)
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


        return await QueryAsync<CustomerQueryResult>(query, parms);
    }
}