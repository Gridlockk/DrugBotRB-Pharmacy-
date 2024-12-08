using Domain.Primitives;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators;

public class AdressValidator : AbstractValidator<Address>
{
    public AdressValidator()
    {
        RuleFor(d => d.Street)
            .Length(3, 100).WithMessage(ValidationMessage.LengthRangeMessage);
        RuleFor(d => d.City)
            .Length(2, 50).WithMessage(ValidationMessage.LengthRangeMessage);
        RuleFor(d => d.PostalCode)
            .Must(PostalCode =>PostalCode <100000 && PostalCode > 10000).WithMessage(ValidationMessage.LengthRangeMessage);
        RuleFor(d => d.Country)
            .Must(CountryValidator.IsValid).WithMessage(ValidationMessage.IsoError);
    }
}

