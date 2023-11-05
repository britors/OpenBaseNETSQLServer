using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Application.Interfaces.Extension;

namespace ProjectTemplate.Application.Interfaces.Services;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeComDapperAsync(BuscaClienteRequest request);

    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeAsync(BuscaClienteRequest request);
}