using ProjectTemplate.Application.DTOs.Cliente;

namespace ProjectTemplate.Application.Interfaces;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> GetByNameAsync(BuscaClienteRequest request);
}