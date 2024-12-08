using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .Must(cost => Decimal.Round(cost, 2) == cost);

        RuleFor(d => d.Count)
            .Must(Count => Count < 10000).WithMessage(ValidationMessage.CountError);
    }
}