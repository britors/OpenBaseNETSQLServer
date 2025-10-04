using Dapper;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.QueryResults;
using OpenBaseNET.Infra.Data.Context;
using System.Data;

namespace OpenBaseNET.Infra.Data.Repositories;

public sealed class CustomerRepository(
    DbSession dbSession,
    ILogger<RepositoryBase<Customer>> logger,
    OneBaseDataBaseContext context)
    : RepositoryBase<Customer>(dbSession, logger, context), ICustomerRepository, IDataRepository
{
    public async Task<IEnumerable<CustomerQueryResult>> FindByNameAsync(
        string name,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        const string query = """
                             SELECT
                                Id AS Id,
                                Name AS Name
                             FROM Customers
                             WHERE Name LIKE @Name
                             ORDER BY Id ASC
                             OFFSET (@PageNumber-1)*@PageSize ROWS
                                FETCH NEXT @PageSize ROWS ONLY
                             """;

        var parameters = new DynamicParameters();
        parameters.Add("@Name", $"%{name}%", DbType.String, ParameterDirection.Input);
        parameters.Add("@PageNumber", pageNumber, DbType.Int32, ParameterDirection.Input);
        parameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

        return await QueryAsync<CustomerQueryResult>(query, cancellationToken, parameters)
               ?? throw new InvalidOperationException();
    }

    public async Task<CountQueryResult> CustomerCoutAsync(string name, CancellationToken cancellationToken)
    {
        var queryCount = $"SELECT COUNT(1) AS TOTAL FROM Customers WHERE UPPER(Name) LIKE '%{name.ToUpper()}%'";
        return await QueryFirstOrDefaultAsync<CountQueryResult>(queryCount, cancellationToken);
    }
}