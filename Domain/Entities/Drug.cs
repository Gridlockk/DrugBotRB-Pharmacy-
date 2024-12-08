using Ardalis.GuardClauses;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Drug : BaseEntity
    {
        public Drug(string name, string manufacturer, string countryCodeId)
        {
            try
            {
                Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
                Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer));
                CountryCodeId = Guard.Against.NullOrWhiteSpace(countryCodeId, nameof(countryCodeId));
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

            var validator = new DrugValidator();
            validator.Validate(this);
        }

        /// <summary>
        /// Название препарата.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Производитель препарата.
        /// </summary>
        public string Manufacturer { get; private set; }
        
        /// <summary>
        /// Код страны производителя.
        /// </summary>
        public string CountryCodeId { get; private set; }
    }
}