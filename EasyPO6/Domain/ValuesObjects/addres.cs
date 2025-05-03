namespace Domain.ValuesObjects;
public partial record Addres{
    public Addres(string country, string line1, string line2,string states,string city, string zipCode )
    {
        Country = country;
        Line1 = line1;
        Line2 = line2;
        City = city;
        States = states;
        ZipCode = zipCode;
    }

    public string Country {get; init;}
    public string Line1 {get; init;}
    public string Line2 {get; init;}
    public string City {get; init;}
    public string States {get; init;}
    public string ZipCode {get; init;}
    public static Addres? Create(string country, string line1, string line2,string states,string city, string zipCode )
    {
        if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(line1) || string.IsNullOrEmpty(line2) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(states) || string.IsNullOrEmpty(zipCode))
        {
            return null;
        }
        return new Addres(country,line1,line2,city,states,zipCode);
    }
}