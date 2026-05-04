using System.Data.SqlClient;
using server.Accessors.IAccessors;

namespace server.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM UserAccount WHERE UserId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE UserAccount SET " + data + " = @new_value WHERE UserId = @id;";
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

        public void SetInt(int id, string data, int new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetInt(id, sql, new_value);
        }

        public void SetString(int id, string data, string new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetString(id, sql, new_value);
        }

        public void SetDateTime(int id, string data, DateTime new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetDateTime(id, sql, new_value);
        }

        public int GetIdFromUsername(string username)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT UserId FROM UserAccount WHERE Username = @username;";
            int output = -1;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Value = username;
                try
                {
                    cmd.Connection.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        output = (int)result;
                    }
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
    }
}
