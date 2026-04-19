namespace server.IAccessors
{
    public interface IUserAccessor
    {
        /*
        Returns an SQL query for use by a Getter.
        */
        public string GetSqlString(string data);

        /*
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(int id, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(int id, string data);

        /*
        Returns a DateTime object from the database based on specified
        parameters.
        */
        public DateTime GetDateTime(int id, string data);

        /*
        Returns a UserId associated with `username` from the database.
        */
        public int GetIdFromUsername(string username);

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