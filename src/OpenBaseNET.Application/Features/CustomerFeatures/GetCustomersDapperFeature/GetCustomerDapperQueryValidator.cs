using FluentValidation;


namespace OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersDapperFeature;

public class GetCustomerDapperQueryValidator : AbstractValidator<GetCustomerDapperQuery>
{
    public GetCustomerDapperQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O número da página deve ser maior ou igual a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(5)
            .WithMessage("O tamanho da página deve ser maior ou igual a 5.");
    }
}