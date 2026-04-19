using System.Data.SqlClient;

namespace server.IAccessors
{
    public interface IGenericAccessor
    {
        /*
        Returns a valid SqlConnection object with admin privileges
        */
        public abstract static SqlConnection GetConnection();

        /*
        Returns an int from the database based on specified parameters.
        */
        public abstract static int GetInt(int id, string sql);

        /*
        Returns a string from the database based on specified parameters.
        */
        public abstract static string GetString(int id, string sql);

        /*
        Returns a DateTime object from the database based on specified
        parameters.
        */
        public abstract static DateTime GetDateTime(int id, string sql);
    }
}