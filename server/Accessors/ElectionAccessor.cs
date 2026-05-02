using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class ElectionAccessor : IElectionAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Elections WHERE ElectionId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Elections SET " + data + " = @new_value WHERE ElectionId = @id;";
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

        public int GetElectionIdFromElectionName(string name)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT ElectionId FROM Elections WHERE ElectionName = @name;";
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@name"].Value = name;
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

        /*
        Queries the Elections table and returns every ElectionName as a
        list of strings. No filtering is applied. all elections are
        returned regardless of publish status.
        */
        public List<string> GetAllElectionNames()
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT ElectionName FROM Elections;";
            List<string> electionNames = new List<string>();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        /* Read each row and add the election name to the list */
                        while (reader.Read())
                        {
                            electionNames.Add(reader.GetString(0));
                        }
                    }
                }
                catch (SqlException sx)
                {
                    /* Log the error and return whatever was collected (may be empty) */
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }

            return electionNames;
        }
    }
}