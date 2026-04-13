class Voter : User
{
    private string FirstName;
    private string LastName;
    private string DateOfBirth;
    private string StreetAddress;
    private string City;
    private string State;
    private string ZipCode;
    private string Precinct;
    private bool IsRegistered;

    public Voter(string username, string password, string email, string firstName, string lastName, string dateOfBirth, string streetAddress, string city, string state, string zipCode, string precinct, bool isRegistered)
        : base(username, password, email)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        StreetAddress = streetAddress;
        City = city;
        State = state;
        ZipCode = zipCode;
        Precinct = precinct;
        IsRegistered = isRegistered;
    }
}