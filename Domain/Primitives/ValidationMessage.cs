namespace Domain.Primitives;

public static class ValidationMessage
{
    public const string LengthRangeMessage ="Поле {PropertyName} должно содержать от {MinLenght} до {MaxLenght} символов";
    public const string WrongCharacters ="Поле {PropertyName} содержит недопустимый символ!";
    public const string LenghtMessage ="Поле {PropertyName} должно содержать только {Lenght}";
    public const string IsoError ="Поле {PropertyName} должно соответствовать формату ISO-2";
    public const string CountError ="Поле {PropertyName} должно быть не более 10000";

}