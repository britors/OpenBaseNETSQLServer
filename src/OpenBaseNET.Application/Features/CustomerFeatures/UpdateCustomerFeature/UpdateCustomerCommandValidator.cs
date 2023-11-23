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
            .MaximumLength(255)
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage("O nome do cliente deve ter entre 5 e 255 caracteres.");
    }
}