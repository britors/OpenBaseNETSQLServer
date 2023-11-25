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
            .WithMessage("O nome do cliente deve ter mais de 5 caracteres.");

        RuleFor(x => x.Name)
            .MaximumLength(2555)
            .WithMessage("O nome do cliente deve ter menos  de 255 caracteres.");
    }
}