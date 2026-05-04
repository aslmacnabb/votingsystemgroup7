using System.Data.SqlClient;
using server.Accessors.IAccessors;

namespace server.Accessors
{
    public class VoteAccessor : IVoteAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Votes WHERE VoteId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Votes SET " + data + " = @new_value WHERE VoteId = @id;";
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

        public void AddVote(int ballotId, int? candidateId, int? measureId, int? officeId, string selectionValue)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; INSERT INTO Votes (BallotId, OfficeId, CandidateId, MeasureId, SelectionValue, RecordedAt) VALUES (@ballotId, @officeId, @candidateId, @measureId, @selectionValue, GETDATE());";
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ballotId", System.Data.SqlDbType.Int).Value = ballotId;
                cmd.Parameters.Add("@officeId", System.Data.SqlDbType.Int).Value = (object)officeId ?? DBNull.Value;
                cmd.Parameters.Add("@candidateId", System.Data.SqlDbType.Int).Value = (object)candidateId ?? DBNull.Value;
                cmd.Parameters.Add("@measureId", System.Data.SqlDbType.Int).Value = (object)measureId ?? DBNull.Value;
                cmd.Parameters.Add("@selectionValue", System.Data.SqlDbType.NVarChar, 200).Value = selectionValue;
                
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

        public List<dynamic> GetUserVotes(int userId)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = @"use VotingSystemDB; 
                SELECT v.VoteId, v.BallotId, v.OfficeId, v.CandidateId, v.MeasureId, v.SelectionValue, v.RecordedAt, b.ElectionId
                FROM Votes v
                INNER JOIN Ballots b ON v.BallotId = b.BallotId
                INNER JOIN VoterProfile vp ON b.VoterId = vp.VoterId
                WHERE vp.UserId = @userId
                ORDER BY v.RecordedAt DESC;";
            
            List<dynamic> votes = new List<dynamic>();
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;
                
                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vote = new
                            {
                                VoteId = reader.GetInt32(0),
                                BallotId = reader.GetInt32(1),
                                OfficeId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                CandidateId = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                                MeasureId = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                SelectionValue = reader.GetString(5),
                                RecordedAt = reader.GetDateTime(6),
                                ElectionId = reader.GetInt32(7)
                            };
                            votes.Add(vote);
                        }
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return votes;
        }
    }
}
