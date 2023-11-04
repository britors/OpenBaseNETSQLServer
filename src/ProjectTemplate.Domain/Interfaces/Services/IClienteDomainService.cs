using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IClienteDomainService : IDomainService
    {
        Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeComDapperAsync(string Nome);
    }
}