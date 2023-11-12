using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;

public sealed class FindCustomerByNameQueryValidator : AbstractValidator<FindCustomerByNameQuery>
{
    public FindCustomerByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}