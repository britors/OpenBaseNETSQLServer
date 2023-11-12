using FluentValidation;

namespace OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id do cliente é obrigatório.")
            .NotNull();
    }
}