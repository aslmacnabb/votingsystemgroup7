using server.IAccessors;

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

        public void SetMeasureDecision(int ballotId, string new_value)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET SubmissionStatus = @new_value WHERE BallotId = @id;";
            GenericAccessor.SetString(ballotId, sql, new_value);
        }

        public DateTime GetBallotDate(int ballotId)
        {
            string sql = "use VotingSystemDB; SELECT CastAt FROM Ballots WHERE BallotId = @id;";
            return GenericAccessor.GetDateTime(ballotId, sql);
        }

        public void SetBallotDate(int ballotId, DateTime new_value)
        {
            string sql = "use VotingSystemDB; UPDATE Ballots SET CastAt = @new_value WHERE BallotId = @id;";
            GenericAccessor.SetDateTime(ballotId, sql, new_value);
        }
    }
}
