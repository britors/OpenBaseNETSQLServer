using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Interfaces.Extension;

namespace ProjectTemplate.Application.Interfaces.Services;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> GetByNameAsync(BuscaClienteRequest request);
}