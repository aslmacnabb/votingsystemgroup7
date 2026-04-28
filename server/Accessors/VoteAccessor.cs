using server.IAccessors;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class VoteAccessor : IVoteAccessor
    {
        /// <summary>
        /// Builds a SQL SELECT statement for a Vote row by its VoteId.
        /// </summary>
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Votes WHERE VoteId = @id;";
        }

        /// <summary>
        /// Builds a SQL UPDATE statement for a Vote row by its VoteId.
        /// </summary>
        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Votes SET " + data + " = @new_value WHERE VoteId = @id;";
        }

        /// <summary>
        /// Reads an integer field from the Votes table for the specified VoteId.
        /// </summary>
        public int GetInt(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetInt(id, sql);
        }

        /// <summary>
        /// Reads a string field from the Votes table for the specified VoteId.
        /// </summary>
        public string GetString(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetString(id, sql);
        }

        /// <summary>
        /// Reads a DateTime field from the Votes table for the specified VoteId.
        /// </summary>
        public DateTime GetDateTime(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetDateTime(id, sql);
        }

        /// <summary>
        /// Updates an integer column on a Vote row for the specified VoteId.
        /// </summary>
        public void SetInt(int id, string data, int new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetInt(id, sql, new_value);
        }

        /// <summary>
        /// Updates a string column on a Vote row for the specified VoteId.
        /// </summary>
        public void SetString(int id, string data, string new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetString(id, sql, new_value);
        }

        /// <summary>
        /// Updates a DateTime column on a Vote row for the specified VoteId.
        /// </summary>
        public void SetDateTime(int id, string data, DateTime new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetDateTime(id, sql, new_value);
        }

        /// <summary>
        /// Inserts a new vote record for the specified ballot and measure.
        /// </summary>
        /// <param name="ballotId">The ballot identifier that the vote belongs to.</param>
        /// <param name="measureId">The measure identifier being voted on.</param>
        /// <param name="selection">The selected value for the measure.</param>
        /// <remarks>
        /// Uses parameterized SQL to bind values safely, opens the connection, executes the insert,
        /// and logs any SqlException to the console. This method writes to the Votes table.
        /// </remarks>
        public void InsertMeasureVote(int ballotId, int measureId, string selection)
        {
            string sql = "use VotingSystemDB; INSERT INTO Votes (BallotId, MeasureId, SelectionValue) VALUES (@ballotId, @measureId, @selection);";
            SqlConnection conn = GenericAccessor.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int);
                cmd.Parameters["@ballotId"].Value = ballotId;
                cmd.Parameters.Add("@measureId", System.Data.SqlDbType.Int);
                cmd.Parameters["@measureId"].Value = measureId;
                cmd.Parameters.Add("@selection", System.Data.SqlDbType.NVarChar, 200);
                cmd.Parameters["@selection"].Value = selection;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
        }
    }
}
