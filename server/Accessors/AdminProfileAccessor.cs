using server.IAccessors;

namespace server.Accessors
{
    public class AdminProfileAccessor : IAdminProfileAccessor
    {
        public string GetSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM AdminProfile WHERE AdminId = @id;";
        }
        public int GetInt(int id, string data)
        {
            string sql = GetSqlString(data);
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = GetSqlString(data);
            return GenericAccessor.GetString(id, sql);
        }

        public DateTime GetDateTime(int id, string data)
        {
            string sql = GetSqlString(data);
            return GenericAccessor.GetDateTime(id, sql);
        }
    }
}