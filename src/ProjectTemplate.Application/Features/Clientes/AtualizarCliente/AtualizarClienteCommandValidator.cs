using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.AtualizarCliente;

public sealed class AtualizarClienteCommandValidator
    : AbstractValidator<AtualizarClienteCommand>
{
    public AtualizarClienteCommandValidator()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}