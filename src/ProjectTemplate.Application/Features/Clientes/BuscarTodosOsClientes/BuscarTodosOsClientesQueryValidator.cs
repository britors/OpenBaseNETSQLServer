using FluentValidation;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarTodosOsClientesQueryValidator : AbstractValidator<BuscarTodosOsClientesQuery>
{
    public BuscarTodosOsClientesQueryValidator()
    {
    }
}