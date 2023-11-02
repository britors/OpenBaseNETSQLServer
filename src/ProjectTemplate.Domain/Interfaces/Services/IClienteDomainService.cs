using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IClienteDomainService : IDomainService
    {
        Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome);
    }
}