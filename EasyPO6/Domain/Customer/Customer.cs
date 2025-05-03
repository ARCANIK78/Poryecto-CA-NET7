using Domain.Primitives;
using Domain.ValuesObjects;

namespace  Domain.Customers;
public sealed class Customer : AgregateRoot
{
    public Customer(CustomerID id, string name, string lastName, string email,
        PhoneNumber phoneNumber, Addres addres, bool activie )
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        Addres = addres;
        Activie = activie;
    }
    private Customer()
    {
    }

    public CustomerID Id { get; private set; }
    public string Name { get; private set;} = string.Empty;
    public string LastName {get;  set;} = string.Empty;
    public string FullName => $"{Name}{LastName}";
    public string Email {get; private set;} = string.Empty;
    public PhoneNumber PhoneNumber {get; private set;}
    public Addres Addres { get; private set; }
    public bool Activie { get; set; }

}