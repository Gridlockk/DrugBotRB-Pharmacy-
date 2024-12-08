using Ardalis.GuardClauses;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// </summary>
    public class DrugItem : BaseEntity
    {
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count)
        {
            try
            {
                DrugId = drugId;
                DrugStoreId = drugStoreId;
                Cost = Guard.Against.NegativeOrZero(cost);
                Count = Guard.Against.Negative(count);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.ParamName} Аргумент не может быть");
            }
            catch 
            {
                Console.WriteLine( "Фатальная ошибка");
            }
            var validator = new DrugItemValidator();
            validator.Validate(this);
        
        }

        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }
        
        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid DrugStoreId { get; private set; }
        
        /// <summary>
        /// Стоимость препарата в данной аптеке.
        /// </summary>
        public decimal Cost { get; private set; }
        
        /// <summary>
        /// Количество препарата на складе.
        /// </summary>
        public int Count { get; private set; }
    }
}