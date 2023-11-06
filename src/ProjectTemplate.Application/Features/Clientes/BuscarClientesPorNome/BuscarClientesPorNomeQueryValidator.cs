using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarClientesPorNomeQueryValidator : AbstractValidator<BuscarClientesPorNomeQuery>
{
    public BuscarClientesPorNomeQueryValidator()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}