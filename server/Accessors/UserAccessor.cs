using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = 192.168.122.252;" +
            "Initial Catalog=TestDB;" +
            "User id=sa;" +
            "Password=Charter9 Untapped Carnivore;";
            return conn;
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
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT AccountType FROM UserAccount WHERE Username = @username;";
            string type;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
                try
                {
                    cmd.Connection.Open();
                    type = (string)cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                    type = "Error";
                }
                cmd.Connection.Close();
            }
            return type;
        }

        public string GetUserEmail(string username)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT Email FROM UserAccount WHERE Username = @username;";
            string email;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
                try
                {
                    cmd.Connection.Open();
                    email = (string)cmd.ExecuteScalar();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                    email = "Error";
                }
                cmd.Connection.Close();
            }
            return email;
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