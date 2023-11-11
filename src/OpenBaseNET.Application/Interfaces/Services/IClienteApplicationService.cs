using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Cliente.Requests;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Application.Interfaces.Extension;

namespace OpenBaseNET.Application.Interfaces.Services;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeComDapperAsync(BuscaClientePorNomeRequest request);

    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeAsync(BuscaClientePorNomeRequest request);

    Task<AtualizarClienteResponse?> AtualizarAsync(AtualizarClienteRequest request);

    Task<CadastrarClienteResponse?> CadastrarAsync(CadastrarClienteRequest request);

    Task<DeletarClienteResponse?> DeletarAsync(DeletarClienteRequest request);

    Task<BuscaClienteResponse> BuscarClienteAsync(BuscaClienteRequest request);

    Task<PaginatedResponse<BuscaClienteResponse>> TodosOsClientesAsync(TodosOsClientesRequest request);
}