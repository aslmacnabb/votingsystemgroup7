using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class GenericAccessor : IGenericAccessor
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = localhost;" +
            "Initial Catalog=VotingSystemDB;" +
            "User id=sa;" +
            "Password=Charter9 Untapped Carnivore;";
            return conn;
        }

        public static int GetInt(int id, string sql)
        {
            SqlConnection conn = GetConnection();
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    output = (int)cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                    output = -1;
                }
                cmd.Connection.Close();
            }
            return output;
        }

        public static string GetString(int id, string sql)
        {
            SqlConnection conn = GetConnection();
            string output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    output = (string)cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                    output = "Error";
                }
                cmd.Connection.Close();
            }
            return output;
        }

        public static DateTime GetDateTime(int id, string sql)
        {
            SqlConnection conn = GetConnection();
            DateTime output = new DateTime();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    output = (DateTime)cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return output;
        }

        public static void SetInt(int id, string sql, int new_value)
        {
            SqlConnection conn = GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@new_value", System.Data.SqlDbType.Int);
                cmd.Parameters["@new_value"].Value = new_value;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
        }

        public static void SetString(int id, string sql, string new_value)
        {
            SqlConnection conn = GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@new_value", System.Data.SqlDbType.NVarChar, 2000);
                cmd.Parameters["@new_value"].Value = new_value;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
        }

        public static void SetDateTime(int id, string sql, DateTime new_value)
        {
            SqlConnection conn = GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@new_value", System.Data.SqlDbType.DateTime2);
                cmd.Parameters["@new_value"].Value = new_value;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
        }
    }
}
