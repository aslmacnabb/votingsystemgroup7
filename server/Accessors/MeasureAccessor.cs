using server.IAccessors;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace server.Accessors
{
    public class MeasureAccessor : IMeasureAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Measures WHERE MeasureId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Measures SET " + data + " = @new_value WHERE MeasureId = @id;";
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

        /// <summary>
        /// Retrieves all measures for a specific election from the database.
        /// </summary>
        /// <param name="electionId">The election identifier to fetch measures for.</param>
        /// <returns>A list of dictionaries containing measure data (MeasureId, MeasureTitle, MeasureText, YesDescription, NoDescription).</returns>
        /// <remarks>Results are ordered by DisplayOrder. Null descriptions are handled and included as null in the returned dictionary.</remarks>
        public List<Dictionary<string, object>> GetMeasuresForElection(int electionId)
        {
            List<Dictionary<string, object>> measures = new List<Dictionary<string, object>>();
            string sql = "use VotingSystemDB; SELECT MeasureId, MeasureTitle, MeasureText, YesDescription, NoDescription FROM Measures WHERE ElectionId = @electionId ORDER BY DisplayOrder;";
            SqlConnection conn = GenericAccessor.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@electionId", System.Data.SqlDbType.Int);
                cmd.Parameters["@electionId"].Value = electionId;
                try
                {
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Dictionary<string, object> measure = new Dictionary<string, object>();
                        measure["MeasureId"] = reader.GetInt32(0);
                        measure["MeasureTitle"] = reader.GetString(1);
                        measure["MeasureText"] = reader.GetString(2);
                        measure["YesDescription"] = reader.IsDBNull(3) ? null : reader.GetString(3);
                        measure["NoDescription"] = reader.IsDBNull(4) ? null : reader.GetString(4);
                        measures.Add(measure);
                    }
                    reader.Close();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return measures;
        }

        /// <summary>
        /// Inserts a new measure record into the database for a specific election.
        /// </summary>
        /// <param name="electionId">The election identifier to associate with the measure.</param>
        /// <param name="title">The measure title (max 200 characters).</param>
        /// <param name="text">The measure description text (max 2000 characters).</param>
        /// <param name="yesDesc">Optional description for voting yes (max 500 characters); can be null.</param>
        /// <param name="noDesc">Optional description for voting no (max 500 characters); can be null.</param>
        /// <remarks>Uses parameterized SQL to prevent injection attacks. Null descriptions are stored as DBNull.</remarks>
        public void InsertMeasure(int electionId, string title, string text, string yesDesc, string noDesc)
        {
            string sql = "use VotingSystemDB; INSERT INTO Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription) VALUES (@electionId, @title, @text, @yesDesc, @noDesc);";
            SqlConnection conn = GenericAccessor.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@electionId", System.Data.SqlDbType.Int);
                cmd.Parameters["@electionId"].Value = electionId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar, 200);
                cmd.Parameters["@title"].Value = title;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar, 2000);
                cmd.Parameters["@text"].Value = text;
                cmd.Parameters.Add("@yesDesc", System.Data.SqlDbType.NVarChar, 500);
                cmd.Parameters["@yesDesc"].Value = yesDesc ?? (object)DBNull.Value;
                cmd.Parameters.Add("@noDesc", System.Data.SqlDbType.NVarChar, 500);
                cmd.Parameters["@noDesc"].Value = noDesc ?? (object)DBNull.Value;
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

        /// <summary>
        /// Retrieves all measures associated with a specific ballot.
        /// </summary>
        /// <param name="ballotId">The ballot identifier to fetch measures for.</param>
        /// <returns>A list of dictionaries containing measure data (MeasureId, MeasureTitle, MeasureText, YesDescription, NoDescription).</returns>
        /// <remarks>Uses an INNER JOIN between Measures and Elections tables to find measures by ballot. Results are ordered by DisplayOrder. Null descriptions are handled and included as null in the returned dictionary.</remarks>
        public List<Dictionary<string, object>> GetMeasuresForBallot(int ballotId)
        {
            List<Dictionary<string, object>> measures = new List<Dictionary<string, object>>();
            string sql = "use VotingSystemDB; SELECT m.MeasureId, m.MeasureTitle, m.MeasureText, m.YesDescription, m.NoDescription FROM Measures m INNER JOIN Elections e ON m.ElectionId = e.ElectionId WHERE e.BallotId = @ballotId ORDER BY m.DisplayOrder;";
            SqlConnection conn = GenericAccessor.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int);
                cmd.Parameters["@ballotId"].Value = ballotId;
                try
                {
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Dictionary<string, object> measure = new Dictionary<string, object>();
                        measure["MeasureId"] = reader.GetInt32(0);
                        measure["MeasureTitle"] = reader.GetString(1);
                        measure["MeasureText"] = reader.GetString(2);
                        measure["YesDescription"] = reader.IsDBNull(3) ? null : reader.GetString(3);
                        measure["NoDescription"] = reader.IsDBNull(4) ? null : reader.GetString(4);
                        measures.Add(measure);
                    }
                    reader.Close();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return measures;
        }

        /// <summary>
        /// Inserts a new measure for a specific ballot by looking up the ballot's associated election.
        /// </summary>
        /// <param name="ballotId">The ballot identifier to associate the measure with (indirectly through its election).</param>
        /// <param name="title">The measure title (max 200 characters).</param>
        /// <param name="text">The measure description text (max 2000 characters).</param>
        /// <param name="yesDesc">Optional description for voting yes (max 500 characters); can be null.</param>
        /// <param name="noDesc">Optional description for voting no (max 500 characters); can be null.</param>
        /// <remarks>This method uses a subquery to find the ElectionId for the given BallotId, then inserts the measure with that election ID. Uses parameterized SQL to prevent injection attacks. Null descriptions are stored as DBNull.</remarks>
        public void InsertMeasureForBallot(int ballotId, string title, string text, string yesDesc, string noDesc)
        {
            string sql = "use VotingSystemDB; INSERT INTO Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription) SELECT ElectionId, @title, @text, @yesDesc, @noDesc FROM Elections WHERE BallotId = @ballotId;";
            SqlConnection conn = GenericAccessor.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int);
                cmd.Parameters["@ballotId"].Value = ballotId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar, 200);
                cmd.Parameters["@title"].Value = title;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar, 2000);
                cmd.Parameters["@text"].Value = text;
                cmd.Parameters.Add("@yesDesc", System.Data.SqlDbType.NVarChar, 500);
                cmd.Parameters["@yesDesc"].Value = yesDesc ?? (object)DBNull.Value;
                cmd.Parameters.Add("@noDesc", System.Data.SqlDbType.NVarChar, 500);
                cmd.Parameters["@noDesc"].Value = noDesc ?? (object)DBNull.Value;
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
