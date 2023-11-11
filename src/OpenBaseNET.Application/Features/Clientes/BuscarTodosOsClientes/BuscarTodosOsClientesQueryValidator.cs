using FluentValidation;

namespace OpenBaseNET.Application.Features.Clientes.BuscarTodosOsClientes;

public sealed class BuscarTodosOsClientesQueryValidator : AbstractValidator<BuscarTodosOsClientesQuery>
{
    public BuscarTodosOsClientesQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O número da página deve ser maior ou igual a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O tamanho da página deve ser maior ou igual a 1.");
    }
}