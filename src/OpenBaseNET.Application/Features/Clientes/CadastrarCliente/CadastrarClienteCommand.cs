using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.CadastrarCliente;

public sealed class CadastrarClienteCommand : IRequest<CadastrarClienteResponse?>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}