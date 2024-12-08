namespace Domain.ValueObjects;

public class Address
{
    public Address(string city, string street, string house)
    {
        City = city;
        Street = street;
        House = house;
    }

    public string City { get; private set; }
    
    public string Street { get; private set; }
    
    public string House { get; private set; }

    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
}