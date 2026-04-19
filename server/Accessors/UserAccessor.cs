using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        public int GetInt(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
            return GenericAccessor.GetString(id, sql);
        }

        public DateTime GetDateTime(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
            return GenericAccessor.GetDateTime(id, sql);
        }

        public int GetIdFromUsername(string username)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
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
            string expectedPassword = GetString(id, "PasswordHash");
            if (password == expectedPassword)
            {
                return true;
            } else
            {
                return false;
            }
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