using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;

public sealed class BuscarClientesPorNomeComDapperValidator : AbstractValidator<BuscarClientesPorNomeComDapperQuery>
{
    public BuscarClientesPorNomeComDapperValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do cliente não pode ser vazio.");
    }
}