using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome do cliente não pode ser vazio.");

        RuleFor(x => x.Name)
            .MinimumLength(5)
            .MaximumLength(255)
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage("O nome do cliente deve ter entre 5 e 255 caracteres.");
    }
}