using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.DeletarCliente;

public sealed class DeletarClienteCommandValidator : AbstractValidator<DeletarClienteCommand>
{
    public DeletarClienteCommandValidator()
    {
    }
}