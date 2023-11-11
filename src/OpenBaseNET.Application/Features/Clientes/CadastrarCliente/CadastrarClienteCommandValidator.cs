using FluentValidation;

namespace OpenBaseNET.Application.Features.Clientes.CadastrarCliente;

public sealed class CadastrarClienteCommandValidator : AbstractValidator<CadastrarClienteCommand>
{
    public CadastrarClienteCommandValidator()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}