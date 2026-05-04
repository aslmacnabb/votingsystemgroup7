public class User
{
#pragma warning disable CS0169 
    private string Username;
    private string Password;
    private string Email;
    private bool IsActive;
    private DateTime DateCreated;
#pragma warning restore CS0169

    public User()
    {
        Username = "";
        Password = "";
        Email = "";
        IsActive = false;
        DateCreated = DateTime.Now;
    }

    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
        IsActive = false;
        DateCreated = DateTime.Now;
    }
}