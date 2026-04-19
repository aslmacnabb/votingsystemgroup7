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

        public int GetInt(int id, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
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

        public string GetString(int id, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
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

        public DateTime GetDateTime(int id, string data)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
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

        public int GetIdFromUsername(string username)
        {
            SqlConnection conn = GetConnection();
            string sql = "use VotingSystemDB; SELECT UserId FROM UserAccount WHERE Username = @username;";
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters[@username].Value = username;
                try
                {
                    cmd.Connection.Open();
                    output = (int)cmd.ExecuteScalar();
                } catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                    output = -1;
                }
                cmd.Connection.Close();
            }
            return output;
        }
        
        public bool Authenticate(string username, string password)
        {
            int id = GetIdFromUsername(username);
            string expectedPassword = GetPasswordHash(id);
            if (password == expectedPassword)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string GetPasswordHash(int id)
        {
            return GetString(id, "PasswordHash");
        }

        public string GetEmail(int id)
        {
            return GetString(id, "Email");
        }

        public string GetAccountType(int id)
        {
            return GetString(id, "AccountType");
        }

        public bool GetActiveStatus(int id)
        {
            int IsActive = GetInt(id, "IsActive");
            if (IsActive == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public DateTime GetCreatedDate(int id)
        {
            return GetDateTime(id, "CreatedDate");
        }

        public DateTime GetLastLoginDate(int id)
        {
            return GetDateTime(id, "LastLogin");
        }

        public int GetFailedLoginAttempts(int id)
        {
            return GetInt(id, "FailedLoginAttempts");
        }

        public DateTime GetLockedUntil(int id)
        {
            return GetDateTime(id, "LockedUntil");
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