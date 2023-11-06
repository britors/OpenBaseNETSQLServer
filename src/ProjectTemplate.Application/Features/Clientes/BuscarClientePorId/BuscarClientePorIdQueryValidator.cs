using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;

public sealed class BuscarClientePorIdQueryValidator : AbstractValidator<BuscarClientePorIdQuery>
{
    public BuscarClientePorIdQueryValidator()
    {
    }
}