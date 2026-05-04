using System.Data.SqlClient;
using server.Accessors.IAccessors;

namespace server.Accessors
{
    public class VoterProfileAccessor : IVoterProfileAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE VoterProfile SET " + data + " = @new_value WHERE VoterId = @id;";
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

        public int GetVoterIdFromUserId(int userid)
        {
            string sql = "use VotingSystemDB; SELECT VoterId FROM VoterProfile WHERE UserId = @id;";
            return GenericAccessor.GetInt(userid, sql);
        }

        public int GetNumberOfVoters()
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT VoterId FROM VoterProfile;";
            int output = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        output = reader.GetInt32(0);
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return output;
        }
    }
}
