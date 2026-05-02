using server.IAccessors;
using System.Collections;
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

        public void SetMeasureDecision(int id, string new_value)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET SubmissionStatus = @new_value WHERE BallotId = @id;";
            GenericAccessor.SetString(id, sql, new_value);
        }

        public DateTime GetBallotDate(int id)
        {
            string sql = "use VotingSystemDB; SELECT CastAt FROM Ballots WHERE BallotId = @id;";
            return GenericAccessor.GetDateTime(id, sql);
        }

        public void SetBallotDate(int id, DateTime new_value)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET CastAt = @new_value WHERE BallotId = @id;";
            GenericAccessor.SetDateTime(id, sql, new_value);
        }

        public int GetBallotId(int electionid, int voterid)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT BallotId FROM Ballots WHERE VoterId = @voterid AND ElectionId = @electionid;";
            int output;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@voterid", System.Data.SqlDbType.Int);
                cmd.Parameters["@voterid"].Value = voterid;
                cmd.Parameters.Add("@electionid", System.Data.SqlDbType.Int);
                cmd.Parameters["@electionid"].Value = electionid;
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

        public string GetMeasureDecision(int id)
        {
            string sql = "SELECT b.SubmissionStatus FROM Measures m INNER JOIN Ballots b ON m.ElectionId = m.ElectionId WHERE b.BallotId = @id";
            return GenericAccessor.GetString(id, sql);
        }

        public List<string> GetMeasuresFromElection(int electionId)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT MeasureTitle FROM Measures WHERE ElectionId = @electionId;";
            List<string> output = new List<string>();
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
                        output.Add(reader.GetString(0));
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

        public void AddBallot(int voterid, int electionid)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken) values (@voterid, @electionid, 'draft', getdate(), 'SESSION_' + convert(varchar(50), newid()) );";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@voterid", System.Data.SqlDbType.Int);
                cmd.Parameters["@voterid"].Value = voterid;
                cmd.Parameters.Add("@electionid", System.Data.SqlDbType.Int);
                cmd.Parameters["@electionid"].Value = electionid;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteScalar();
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
