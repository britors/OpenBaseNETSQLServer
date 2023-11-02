using Dapper;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Context;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.QueryResults;
using ProjectTemplate.Infra.Mssql.Uow;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public sealed class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository, IDataRepository
{
    public ClienteRepository(DbSession dbSession,
                                ProjectDbContext context,
                                SessionContext sessionContext,
                                ILogger<ClienteRepository> logger) : base(dbSession, context, sessionContext, logger)
    {
    }

    public async Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome)
    {
        var query = @"SELECT
                        CLIID AS ID,
                        CLINM AS NOME
                    FROM CLITAB (NOLOCK)
                    WHERE
                        CLINM LIKE @NOME
                    ORDER BY CLINM";

        var parms = new DynamicParameters();
        parms.Add("@Nome", Nome + "%");

        var result = await QueryAsync<ClienteQueryResult>(query, parms);
        return result;
    }
}