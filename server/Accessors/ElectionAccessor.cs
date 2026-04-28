using server.IAccessors;
using System;
using System.Collections.Generic;
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

        // Updates a DateTime field for the specified election.
        public void SetDateTime(int id, string data, DateTime new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetDateTime(id, sql, new_value);
        }

        // Returns the names of published elections as the available ballot names.
        public List<string> GetAvailableBallotNames()
        {
            List<string> ballotNames = new List<string>();
            string sql = "use VotingSystemDB; SELECT ElectionName FROM Elections WHERE IsPublished = 1;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ballotNames.Add(reader.GetString(0));
                        }
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
            return ballotNames;
        }
    }
}
