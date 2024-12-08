using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .Length(2,100).WithMessage(ValidationMessage.LengthRangeMessage);
    }

    
}