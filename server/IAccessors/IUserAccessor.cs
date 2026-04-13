using System.Data.SqlClient;

namespace server.IAccessors 
{
    public interface IUserAccessor
    {
        /**
        * Returns a valid SqlConnection object with admin privileges
        */
        public static abstract SqlConnection GetConnection();

        /**
        * Returns true if the passed username and password are valid.
        */
        public static abstract bool Authenticate(string username, string password);

        /**
        * Returns the user type (voter or admin).
        */
        public static abstract string GetUserType(string username);

        /**
        * Returns a User object with all data fields supplied directly
        * from the database.
        */
        public static abstract User PullUser(string username);

        /**
        * Updates the database with the information contained in the
        * passed User object.
        */
        public static abstract void PushUser(User user);
    }
}