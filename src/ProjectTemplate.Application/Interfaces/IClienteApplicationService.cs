using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Services;

namespace ProjectTemplate.Application.Interfaces;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> GetByNameAsync(BuscaClienteRequest request);
}