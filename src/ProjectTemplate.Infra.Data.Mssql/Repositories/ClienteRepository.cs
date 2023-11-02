using Dapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.QueryResults;
using ProjectTemplate.Infra.Mssql.Uow;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository, IDataRepository
{
    public ClienteRepository(DbSession session, ProjectDbContext Context) : base(session, Context)
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