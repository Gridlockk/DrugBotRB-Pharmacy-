using Ardalis.GuardClauses;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        public DrugStore(string drugNetwork, int number, Address address)
        {
            try
            {
                DrugNetwork = Guard.Against.NullOrWhiteSpace(drugNetwork, nameof(drugNetwork));
                Number = Guard.Against.NegativeOrZero(number, nameof(number));
                Address = Guard.Against.Null(address, nameof(address));
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
            var validator = new DrugStoreValidator();
            validator.Validate(this);

        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
    }
}