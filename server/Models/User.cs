public class User
{
    private string Username;
    private string Password;
    private string Email;
    private bool IsActive;
    private DateTime DateCreated;

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