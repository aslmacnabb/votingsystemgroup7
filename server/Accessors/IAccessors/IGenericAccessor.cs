using System.Data.SqlClient;

namespace server.Accessors.IAccessors
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

        /*
        Sets an int belonging to `id` to `new_value` on field `data`.
        */
        public abstract static void SetInt(int id, string sql, int new_value);

        /*
        Sets a string belonging to `id` to `new_value` on field `data`.
        */
        public abstract static void SetString(int id, string sql, string new_value);

        /*
        Sets a DateTime object belonging to `id` to `new_value` on field `data`.
        */
        public abstract static void SetDateTime(int id, string sql, DateTime new_value);
    }
}
