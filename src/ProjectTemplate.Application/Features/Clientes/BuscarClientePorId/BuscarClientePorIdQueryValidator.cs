using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;

public sealed class BuscarClientePorIdQueryValidator : AbstractValidator<BuscarClientePorIdQuery>
{
    public BuscarClientePorIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O id do cliente não pode ser vazio.");
    }
}