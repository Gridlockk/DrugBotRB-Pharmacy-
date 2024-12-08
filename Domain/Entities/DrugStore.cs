using Domain.ValueObjects;

namespace Domain.Entities;

public class DrugStore : BaseEntity
{
    public DrugStore(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
    }
    
    public string DrugNetwork { get; private set; }
    
    public int Number { get; private set; }
    
    public Address Address { get; private set; }
}