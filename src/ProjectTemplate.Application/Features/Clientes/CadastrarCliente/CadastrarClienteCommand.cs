using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;

namespace ProjectTemplate.Application.Features.Clientes.CadastrarCliente;

public sealed class CadastrarClienteCommand : IRequest<CadastrarClienteResponse?>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}