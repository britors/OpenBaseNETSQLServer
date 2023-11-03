using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarClientesPorNomeQueryValidator : AbstractValidator<BuscarClientesPorNomeQuery>
{
    public BuscarClientesPorNomeQueryValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do cliente não pode ser vazio.");
    }
}