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

        public int GetInt(string username, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE Username = @username;";
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
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

        public string GetString(string username, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE Username = @username;";
            string output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
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

        public DateTime GetDateTime(string username, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE Username = @username;";
            DateTime output = new DateTime();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
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
        
        public bool Authenticate(string username, string password)
        {
            string expectedPassword = GetPasswordHash(username);
            if (password == expectedPassword)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string GetPasswordHash(string username)
        {
            return GetString(username, "PasswordHash");
        }

        public string GetEmail(string username)
        {
            return GetString(username, "Email");
        }

        public string GetAccountType(string username)
        {
            return GetString(username, "AccountType");
        }

        public bool GetActiveStatus(string username)
        {
            int IsActive = GetInt(username, "IsActive");
            if (IsActive == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public DateTime GetCreatedDate(string username)
        {
            return GetDateTime(username, "CreatedDate");
        }

        public DateTime GetLastLoginDate(string username)
        {
            return GetDateTime(username, "LastLogin");
        }

        public int GetFailedLoginAttempts(string username)
        {
            return GetInt(username, "FailedLoginAttempts");
        }

        public DateTime GetLockedUntil(string username)
        {
            return GetDateTime(username, "LockedUntil");
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