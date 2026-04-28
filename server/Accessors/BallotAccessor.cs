using server.IAccessors;
using System;
using System.Data.SqlClient;

namespace server.Accessors
{
    public class BallotAccessor : IBallotAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Ballots WHERE BallotId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Ballots SET " + data + " = @new_value WHERE BallotId = @id;";
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

        // Returns the ballot submission timestamp (CastAt), or null if the ballot has not been cast
        public DateTime? GetBallotDate(int ballotId)
        {
            DateTime? result = null;
            string sql = "use VotingSystemDB; SELECT CastAt FROM Ballots WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = (DateTime)value;
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
            return result;
        }

        // Saves the ballot submission timestamp into Ballots.CastAt
        public void SetBallotDate(int ballotId, DateTime date)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET CastAt = @date WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@date", System.Data.SqlDbType.DateTime2).Value = date;
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
        }

        // Returns the ballot specific voting window start datetime
        public DateTime? GetBallotStartDate(int ballotId)
        {
            DateTime? result = null;
            string sql = "use VotingSystemDB; SELECT StartDate FROM Ballots WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = (DateTime)value;
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
            return result;
        }

        // Saves the ballot specific voting window start datetime
        public void SetBallotStartDate(int ballotId, DateTime date)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET StartDate = @date WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@date", System.Data.SqlDbType.DateTime2).Value = date;
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
        }

        // Returns the ballot-specific voting window end datetime
        public DateTime? GetBallotEndDate(int ballotId)
        {
            DateTime? result = null;
            string sql = "use VotingSystemDB; SELECT EndDate FROM Ballots WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = (DateTime)value;
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
            return result;
        }

        // Saves the ballot specific voting window end datetime
        public void SetBallotEndDate(int ballotId, DateTime date)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET EndDate = @date WHERE BallotId = @ballotId;";
            using (SqlConnection conn = GenericAccessor.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@date", System.Data.SqlDbType.DateTime2).Value = date;
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
            }
        }
    }
}
