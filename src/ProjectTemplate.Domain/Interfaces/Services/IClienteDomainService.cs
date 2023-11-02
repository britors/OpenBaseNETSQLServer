using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IClienteDomainService
    {
        Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome);
    }
}