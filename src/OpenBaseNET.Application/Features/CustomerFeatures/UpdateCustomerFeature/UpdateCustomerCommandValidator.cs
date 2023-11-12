using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;

public sealed class UpdateCustomerCommandValidator
    : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O id do cliente não pode ser vazio.");

        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithMessage("O nome do cliente deve ter no mínimo 5 caracteres.");
    }
}