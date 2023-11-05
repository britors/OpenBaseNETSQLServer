using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarClientesPorNomerQueryValidator : AbstractValidator<BuscarClientesPorNomeQuery>
{
    public BuscarClientesPorNomerQueryValidator()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}