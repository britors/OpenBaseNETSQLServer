using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;

public sealed class BuscarClientesPorNomeComDapperValidator : AbstractValidator<BuscarClientesPorNomeComDapperQuery>
{
    public BuscarClientesPorNomeComDapperValidator()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}