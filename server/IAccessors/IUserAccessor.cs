using System.Data.SqlClient;

namespace server.IAccessors
{
    public interface IUserAccessor
    {
        /**
        * Returns a valid SqlConnection object with admin privileges
        */
        public SqlConnection GetConnection();

        /**
        * Returns true if the passed username and password are valid.
        */
        public bool Authenticate(string username, string password);

        /**
        * Returns the user type (voter or admin).
        */
        public string GetUserType(string username);

        /**
        * Returns a User object with all data fields supplied directly
        * from the database.
        */
        public User PullUser(string username);

        /**
        * Updates the database with the information contained in the
        * passed User object.
        */
        public void PushUser(User user);
    }
}