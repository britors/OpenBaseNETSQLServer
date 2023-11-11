using Dapper;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Context;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.QueryResults;
using ProjectTemplate.Infra.Mssql.Uow;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public sealed class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository, IDataRepository
{
    public ClienteRepository(DbSession dbSession,
        ProjectDbContext context,
        SessionContext sessionContext,
        ILogger<ClienteRepository> logger) :
        base(dbSession, context, sessionContext, logger)
    {
    }

    public async Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome)
    {
        var parms = new DynamicParameters();
        parms.Add("@Nome", Nome + "%");

        const string query = """
                             SELECT
                                 CLIID AS ID,
                                 CLINM AS NOME
                             FROM CLITAB
                             WHERE
                                 CLINM LIKE @NOME
                             """;


        return await QueryAsync<ClienteQueryResult>(query, parms);
    }
}