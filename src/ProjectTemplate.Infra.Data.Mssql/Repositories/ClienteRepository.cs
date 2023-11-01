using Dapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.QueryResults;
using ProjectTemplate.Infra.Mssql.Uow;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
{
    public ClienteRepository(DbSession session, ProjectDbContext Context) : base(session, Context)
    {
    }

    public async Task<IEnumerable<ClienteQueryResult>?> GetByNameAsync(string name)
    {
        var query = @"  SELECT
                            CLIID AS Id,
                            CLINM AS Name
                        FROM CLITAB
                        WHERE
                            CLINM = @Name
                        order by CLINM";

        var parms = new DynamicParameters();
        parms.Add("@Name", name);

        var result = await QueryAsync<ClienteQueryResult>(query, parms);
        return result;
    }
}