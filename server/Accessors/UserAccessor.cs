using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        public SqlConnection GetConnection()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                // TODO: Set the database IP as the program runs
                conn.ConnectionString = "Data Source = 192.168.122.5;" +
                "Initial Catalog=TestDB;" +
                "User id=HUSKERSADMIN;" +
                "Password=CORNADMIN;";
                try
                {
                    conn.Open();
                    return conn;
                }
                catch (Exception es)
                {
                    return null;
                }
            }
        }
        public bool Authenticate(string username, string password)
        {
            string sql = "SELECT user_id FROM USER_ACCOUNT WHERE username = @username AND password_hash = @password_hash";
            using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@password_hash", System.Data.SqlDbType.NVarChar, 25);
                cmd.Parameters["@username"].Value = username;
                // TODO: hash password
                cmd.Parameters["@password_hash"].Value = password;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteScalar();
                    return true;
                }
                catch (SqlException sx)
                {
                    Console.WriteLine("User not found!");
                    return false;
                }
            }
        }

        public string GetUserType(string username)
        {
            string sql = "SELECT type FROM USER_ACCOUNT WHERE username = @username";
            using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
                // TODO: hash password
                try
                {
                    cmd.Connection.Open();
                    string type = (string)cmd.ExecuteScalar();
                    return type;
                }
                catch (SqlException sx)
                {
                    Console.WriteLine("User not found!");
                    return "Invalid";
                }
            }
        }

        public string GetUserEmail(string username)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source = 192.168.122.252;" +
                "Initial Catalog=TestDB;" +
                "User id=sa;" +
                "Password=Charter9 Untapped Carnivore;";
                conn.Open();
                Console.WriteLine("Connection successful!");
                string sql = "use VotingSystemDB; SELECT Email FROM UserAccount WHERE Username = @username;";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@username"].Value = username;
                    try
                    {
                        string email = (string)cmd.ExecuteScalar();
                        cmd.Connection.Close();
                        return email;
                    }
                    catch (SqlException sx)
                    {
                        Console.WriteLine(sx);
                        return "Function returned with error";
                    }
                }
            } catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return "Function returned";
        }

        public User PullUser(string username)
        {
            return new User();
        }

        public void PushUser(User user)
        {
            return;
        }
    }
}