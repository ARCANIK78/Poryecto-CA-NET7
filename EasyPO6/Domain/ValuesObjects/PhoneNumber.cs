namespace DOmain.ValueObjects;
public partial record PhoneNumber
{
    private const int defaultLenght = 9;
    private const string Pattern = @"^(?:-*\d-*){8}$";
    private PhoneNumber(string value)
    public status PhoneNumber? Create(string value)
    {
        if(string.IsNullOrEmpty(value) || !PhonewNumberRegex().IsMatch(value) || value.Length != defaultLenght){
            return null;
        }
        return new PhoneNumber(value);
    }
    public string value {get; int}
    public static partial Regex PhonewNumberRegex();
    [GeneratedRegex{Pattern}]
    private static partial Regex PhonewNumberRegex();
}