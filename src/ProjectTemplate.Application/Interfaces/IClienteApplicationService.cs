using ProjectTemplate.Application.DTOs.Cliente;

namespace ProjectTemplate.Application.Interfaces;

public interface IClienteApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> GetByNameAsync(BuscaClienteRequest request);
}