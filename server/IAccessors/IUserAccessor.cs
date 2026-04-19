using System.Data.SqlClient;

namespace server.IAccessors
{
    public interface IUserAccessor
    {
        /*
        Returns a valid SqlConnection object with admin privileges
        */
        public SqlConnection GetConnection();

        /*
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(string username, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(string username, string data);

        public DateTime GetDateTime(string username, string data);

        /*
        Returns true if the passed username and password are valid.
        */
        public bool Authenticate(string username, string password);

        /*
        Returns the password hash associated with `username`.
        */
        public string GetPasswordHash(string username);
        
        /*
        Returns the email associated with `username`.
        */
        public string GetEmail(string username);

        /*
        Returns the user type (voter or admin).
        */
        public string GetAccountType(string username);

        /*
        Returns whether User `username` is active or not.
        */
        public bool GetActiveStatus(string username);

        /*
        Returns the creation date of User `username` as a string.
        */
        public DateTime GetCreatedDate(string username);

        /*
        Returns the time `username` last logged in as a string.
        */
        public DateTime GetLastLoginDate(string username);

        /*
        Returns the number of failed login attempts associated with
        `username`.
        */
        public int GetFailedLoginAttempts(string username);

        /*
        Returns the time that `username` will be unlocked as a string.
        */
        public DateTime GetLockedUntil(string username);

        /*
        Returns a User object with all data fields supplied directly
        from the database.
        */
        public User PullUser(string username);

        /*
        Updates the database with the information contained in the
        passed User object.
        */
        public void PushUser(User user);
    }
}