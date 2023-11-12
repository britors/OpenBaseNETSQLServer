using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;

public sealed class FindCustomerByIdQueryValidator : AbstractValidator<FindCustomerByIdQuery>
{
    public FindCustomerByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O id do cliente não pode ser vazio.");
    }
}