using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapper;

public sealed class FindCustomerByNameUsingDapperValidator
    : AbstractValidator<FindCustomerByNameUsingDapperQuery>
{
    public FindCustomerByNameUsingDapperValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}