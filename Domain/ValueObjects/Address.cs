using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Validators;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Объект значения, представляющий адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="house">Номер дома.</param>
        public Address(string city, string street, string house, int postalcode, string country)
        {
            try
            {
                City = Guard.Against.NullOrWhiteSpace(city, nameof(city));
                Street = Guard.Against.NullOrWhiteSpace(street, nameof(street));
                House = Guard.Against.NullOrWhiteSpace(house, nameof(house));
                PostalCode = Guard.Against.NegativeOrZero(postalcode, nameof(postalcode));
                Country = Guard.Against.NullOrWhiteSpace(country, nameof(country));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"{ex.ParamName} Аргумент не может быть равен Null");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.ParamName} введён неверно");
            }
            catch 
            {
                Console.WriteLine("Фатальная ошибка");
            }
      
            
            var validator = new AdressValidator();
            validator.Validate(this);
        }
        
        /// <summary>
        ///  Код страны
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// Почтоный индекс
        /// </summary>
        public int PostalCode { get; private set; }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; private set; }

        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        public override string ToString()
        {
            return $"{City}, {Street}, {House}";
        }
    }
}