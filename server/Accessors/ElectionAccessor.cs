using server.IAccessors;

namespace server.Accessors
{
    public class ElectionAccessor : IElectionAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Elections WHERE ElectionId = @id;";
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
    }
}
