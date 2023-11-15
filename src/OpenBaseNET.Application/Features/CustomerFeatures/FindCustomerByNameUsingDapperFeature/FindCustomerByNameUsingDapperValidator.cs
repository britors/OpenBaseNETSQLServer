using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;

public sealed class FindCustomerByNameUsingDapperValidator
    : AbstractValidator<FindCustomerByNameUsingDapperQuery>
{
    public FindCustomerByNameUsingDapperValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome do cliente não pode ser vazio.");

        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}