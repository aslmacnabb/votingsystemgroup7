public class User
{
    private string Username;
    private string Password;
    private string Email;
    private bool IsActive;
    private DateTime DateCreated;

    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
        IsActive = false;
        DateCreated = DateTime.Now;
    }
}