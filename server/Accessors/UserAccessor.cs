using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
        }
        public int GetInt(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetString(id, sql);
        }

        public DateTime GetDateTime(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetDateTime(id, sql);
        }

        public int GetIdFromUsername(string username)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT UserId FROM UserAccount WHERE Username = @username;";
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
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
