using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .Length(2, 150).WithMessage(ValidationMessage.LengthRangeMessage)
            .Matches(@"[A-Za-z]+").WithMessage(ValidationMessage.WrongCharacters);
        
        RuleFor(d => d.Manufacturer)
            .Length(2, 100).WithMessage(ValidationMessage.LengthRangeMessage)
            .Matches(@"[A-Za-z\s\-]+").WithMessage(ValidationMessage.WrongCharacters);
        
        RuleFor(d => d.CountryCodeId)
            .Length(2).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[A-Z]+").WithMessage(ValidationMessage.WrongCharacters);
        
    }
}