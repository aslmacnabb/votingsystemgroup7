using server.IAccessors;

namespace server.Accessors
{
    public class VoterProfileAccessor : IVoterProfileAccessor
    {
        public int GetInt(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetString(id, sql);
        }

        public DateTime GetDateTime(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetDateTime(id, sql);
        }
    }
}