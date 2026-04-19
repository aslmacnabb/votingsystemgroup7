namespace server.IAccessors
{
    public interface IUserAccessor
    {
        /*
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(int id, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(int id, string data);

        /*
        Returns a UserId associated with `username` from the database.
        */
        public int GetIdFromUsername(string username);

        /*
        Returns a DateTime object from the database based on specified
        parameters.
        */
        public DateTime GetDateTime(int id, string data);

        /*
        Returns true if the passed username and password are valid.
        */
        public bool Authenticate(string username, string password);

        /*
        Returns the password hash associated with `id`.
        */
        public string GetPasswordHash(int id);
        
        /*
        Returns the email associated with `id`.
        */
        public string GetEmail(int id);

        /*
        Returns the user type (voter or admin).
        */
        public string GetAccountType(int id);

        /*
        Returns whether User `id` is active or not.
        */
        public bool GetActiveStatus(int id);

        /*
        Returns the creation date of User `id`.
        */
        public DateTime GetCreatedDate(int id);

        /*
        Returns the time `id` last logged in.
        */
        public DateTime GetLastLoginDate(int id);

        /*
        Returns the number of failed login attempts associated with
        `id`.
        */
        public int GetFailedLoginAttempts(int id);

        /*
        Returns the time that `id` will be unlocked.
        */
        public DateTime GetLockedUntil(int id);

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